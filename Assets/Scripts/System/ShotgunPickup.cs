using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotgunPickup : MonoBehaviour
{
    public ShotgunProperties shotgun;
    public Transform visualRoot;
    public BoxCollider col;
    public bool destroyOnPickup = true;

    public UnityEvent e_OnPickup;

    void Start()
    {
        var g = Instantiate(shotgun.shotgunVisual, visualRoot);
        Destroy(g.GetComponentInChildren<ShotgunVisual>());
    }

    public void PickUp()
    {
        Player.Instance.EquipNewShotgun(shotgun);

        e_OnPickup.Invoke();

        if (destroyOnPickup)
        {
            col.enabled = false;
            visualRoot.gameObject.SetActive(false);
        }
    }
}
