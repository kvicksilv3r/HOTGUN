using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSoundManager : MonoBehaviour
{
    [SerializeField]
    protected AudioSource source;

    public static ShotgunSoundManager Instance;

    [SerializeField]

    protected AudioClip dryFire;
    [SerializeField]
    protected AudioClip fire;

    [SerializeField]
    protected AudioClip armBack;

    [SerializeField]
    protected AudioClip armBack2;

    [SerializeField]
    protected AudioClip armForward;

    [SerializeField]
    protected AudioClip armForwardShell;

    [SerializeField]
    protected AudioClip insertShell;

    [SerializeField]
    protected float pitchOffset = 0.05f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Instance = this;
    }

    public void DryFire()
    {
        RandomPitch();
        source.PlayOneShot(dryFire);
    }

    public void Fire()
    {
        RandomPitch();
        source.PlayOneShot(fire);
    }

    public void ArmBack()
    {
        RandomPitch();
        source.PlayOneShot(armBack2);
    }

    public void ArmBackNoShell()
    {
        RandomPitch();
        source.PlayOneShot(armBack);
    }

    public void ArmForward()
    {
        RandomPitch();
        source.PlayOneShot(armForward);
    }

    public void ArmForwardWithShell()
    {
        RandomPitch();
        source.PlayOneShot(armForwardShell);
    }

    public void InsertShell()
    {
        RandomPitch();
        source.PlayOneShot(insertShell);
    }

    private void RandomPitch()
    {
        source.pitch = Random.Range(1 - pitchOffset, 1 + pitchOffset);
    }
}
