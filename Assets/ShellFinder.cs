using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFinder : MonoBehaviour
{
    public Animator animator;
    public static ShellFinder Instance;

    private void Awake()
    {
        Instance = this;
        animator = GetComponentInChildren<Animator>();
    }
}
