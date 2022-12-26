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

    public Animator shellAnim;


    public static ShotgunVisual Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shotgun.e_shoot.AddListener(SpawnVfx);
        forearmTarget = forearmForward.position;
    }

    void Update()
    {
        forearmTarget = shotgun.forearmState == ForearmState.Forward ? forearmForward.position : forearmBack.position;
        forearm.position = Vector3.MoveTowards(forearm.position, forearmTarget, forearmDelta * Time.deltaTime);

        shotgunRoot.up = shotgun.shotgunState == ShotgunState.Reloading ? Vector3.down : Vector3.up;
    }

    public void Reload()
    {
        print("hello animate");
        shellAnim.SetTrigger("Reload");
    }

    void SpawnVfx()
    {
        Instantiate(vfx);
    }
}
