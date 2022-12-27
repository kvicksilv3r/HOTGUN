using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionEventTriggerZone : MonoBehaviour
{
    public UnityEvent e_OnTriggerEnter;
    public bool destroyOnTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e_OnTriggerEnter.Invoke();

            if (destroyOnTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
