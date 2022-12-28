using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateBasedInteractionListener : MonoBehaviour
{
    public UnityEvent e_OnStateEvent;
    public StateBasedAction thisAction;

    private void Start()
    {
        switch (thisAction)
        {
            case StateBasedAction.EnterReloadState:
                Shotgun.Instance.e_EnterReloadState.AddListener(TriggerEvent);
                break;
            case StateBasedAction.PutShellInGun:
                Shotgun.Instance.e_PutShellInGun.AddListener(TriggerEvent);
                break;
            case StateBasedAction.FireGun:
                Shotgun.Instance.e_Shoot.AddListener(TriggerEvent);
                break;
            case StateBasedAction.GunFull:
                Shotgun.Instance.e_ShotgunAmmoFull.AddListener(TriggerEvent);
                break;
            case StateBasedAction.ChamberShell:
                Shotgun.Instance.e_ChamberShell.AddListener(TriggerEvent);
                break;
            case StateBasedAction.PlayerJump:
                PlayerMovement.Instance.e_Jump.AddListener(TriggerEvent);
                break;
            case StateBasedAction.ExitReloadState:
                Shotgun.Instance.e_ExitReloadState.AddListener(TriggerEvent);
                break;
            default:
                break;
        }
    }

    private void TriggerEvent()
    {
        e_OnStateEvent.Invoke();
        Destroy(gameObject);
    }
}
