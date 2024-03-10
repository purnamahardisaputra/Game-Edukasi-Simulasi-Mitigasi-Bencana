using DialogueEditor;
using UnityEngine;

public class NPCControllers : MonoBehaviour
{
    public NPCConversation _npcConversation;
    
    [SerializeField] 
    private GameObject _canvasTalkToNPC;
    
    public bool isConversation = false;

    public static NPCControllers Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        _npcConversation = GetComponent<NPCConversation>();
        _canvasTalkToNPC.SetActive(false);
    }

    private void SetGameObjectLookAt(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasTalkToNPC.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _canvasTalkToNPC.SetActive(false);
                this.isConversation = true;
                ConversationManager.Instance.StartConversation(_npcConversation);
            }

            SetGameObjectLookAt(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ConversationManager.Instance.EndConversation();
            this.isConversation = false;
        }
    }
}
