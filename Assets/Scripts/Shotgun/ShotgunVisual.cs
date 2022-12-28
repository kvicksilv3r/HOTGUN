using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotgunVisual : MonoBehaviour
{
    public Transform forearmForward;
    public Transform forearmBack;
    public Transform forearm;
    public Vector3 forearmTarget;
    public Transform shotgunRoot;

    public Transform vfxRoot;
    public ParticleSystem vfx;

    public float rotationDelta = 10f;
    public float forearmDelta = 0.25f;

    public Shotgun shotgun;

    public Animator shellAnimator;

    public static ShotgunVisual Instance;

    void Start()
    {
        Instance = this;

        if (!shotgun)
        {
            shotgun = Shotgun.Instance;
        }

        shotgun.e_Shoot.AddListener(SpawnVfx);
        forearmTarget = forearmForward.position;

        if (!shellAnimator)
        {
            shellAnimator = ShellFinder.Instance.animator;
        }

    }

    void Update()
    {
        forearmTarget = shotgun.forearmState == ForearmState.Forward ? forearmForward.position : forearmBack.position;
        forearm.position = Vector3.MoveTowards(forearm.position, forearmTarget, forearmDelta * Time.deltaTime);

        //shotgunRoot.up = shotgun.shotgunState == ShotgunState.Reloading ? Vector3.down : Vector3.up;
    }

    public void Reload()
    {
        shellAnimator.SetTrigger("Reload");
    }

    void SpawnVfx()
    {
        var fx = Instantiate(vfx);
        fx.transform.position = vfxRoot.position;
        fx.transform.forward = vfxRoot.forward;
        fx.GetComponent<ShotgunPellet>().SetDamage(Player.Instance.shotgun.damage);

        ParticleSystem ps = fx.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        em.rateOverTime = 0;

        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(0f, Player.Instance.shotgun.projectileCount)
            });
    }
}
