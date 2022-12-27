using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyArmIK : MonoBehaviour
{
    public LineRenderer lr;
    public Transform slidy;
    public Transform elbow;
    public Transform shell;
    // Start is called before the first frame update
    private Animator shellAnimator;

    private void Start()
    {
        shellAnimator = ShellFinder.Instance.animator;
        shell = ShellFinder.Instance.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!slidy)
        {
            if (ShotgunVisual.Instance)
            {
                slidy = ShotgunVisual.Instance.forearm;
            }

            if (!slidy)
            {
                return;
            }
        }

        lr.SetPosition(0, elbow.position);

        if (ShellAnimPlaying())
        {
            lr.SetPosition(1, shell.position);
        }

        else
        {
            lr.SetPosition(1, slidy.position);
        }
    }

    private bool ShellAnimPlaying()
    {
        return (shellAnimator.GetCurrentAnimatorStateInfo(0).IsName("ShellAnim") && shellAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
    }
}
