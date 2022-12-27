using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractionActionEvent : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void EnableThis()
    {
        gameObject.SetActive(true);
    }

    public void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
