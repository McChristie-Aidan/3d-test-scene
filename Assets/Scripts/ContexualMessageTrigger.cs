using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContexualMessageTrigger : MonoBehaviour
{
    public delegate void ContextualMessageTriggeredAction();

    public static event ContextualMessageTriggeredAction ContextualMessageTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ContextualMessageTriggered != null)
            {
                ContextualMessageTriggered.Invoke();
            }
        }
    }
}
