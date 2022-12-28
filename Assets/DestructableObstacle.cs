using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObstacle : DamageableEntity
{
    public GameObject destructionVfx;

    public override void Death()
    {
        CreateVfx();
        base.Death();
        Destroy(gameObject);
    }

    private void CreateVfx()
    {
        var vfx = Instantiate(destructionVfx);
        foreach (var fx in vfx.GetComponentsInChildren<ParticleSystem>())
        {
            var main = fx.main;
            main.startColor = gameObject.GetComponent<MeshRenderer>().material.color;
        }
        vfx.transform.position = transform.position;
    }
}
