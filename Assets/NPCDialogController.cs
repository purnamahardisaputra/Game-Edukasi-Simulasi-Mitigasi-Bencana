using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogController : MonoBehaviour
{
    [SerializeField] private NPCConversation _npcConversation;
    public bool isConversation = false;
    float rotationSpeed = 5f;
    float maxRotationAngle = 45f;
    private void Awake()
    {
        _npcConversation = GetComponent<NPCConversation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
