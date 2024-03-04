using System.Collections;
using UnityEngine;
using static Beautify.Universal.Beautify;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject character;
    public static PlayerController Instance;

    private void Start()
    {
        Instance = this;
    }

    private void Awake()
    {
        animator.SetFloat("Speed", 0f);
    }

    private void Update()
    {
        AnimationMove();
    }

    private void AnimationMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void SetInputPlayer()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {

        }
    }

    private void SetGameObjectLookAt(Collider other)
    {
        Debug.Log($"SetGameObjectLookAt : {other.name}");
        Vector3 direction = other.transform.position - character.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, targetRotation, Time.deltaTime);
    }

    #region Trigger Events

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            if(other.GetComponent<NPCControllers>().isConversation == true)
            {
                SetGameObjectLookAt(other);

                other.GetComponentInParent<Animator>().SetBool("Talk", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log($"Exit Trigger NPC {other.gameObject.name}");
            other.GetComponentInParent<Animator>().SetBool("Talk", false);
        }
    }
    #endregion
}
