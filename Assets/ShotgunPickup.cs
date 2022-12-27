using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour
{
    public ShotgunProperties shotgun;
    public Transform visualRoot;
    public BoxCollider col;
    public bool destroyOnPickup = true;
    void Start()
    {
        var g = Instantiate(shotgun.shotgunVisual, visualRoot);
        Destroy(g.GetComponentInChildren<ShotgunVisual>());
    }

    public void PickUp()
    {
        Player.Instance.EquipNewShotgun(shotgun);

        if (destroyOnPickup)
        {
            col.enabled = false;
            visualRoot.gameObject.SetActive(false);
        }
    }
}
