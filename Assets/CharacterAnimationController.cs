using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private GameObject character;
    public static CharacterAnimationController Instance;

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
}
