using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Shotgun shotgun;
    private Player player;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        shotgun = Shotgun.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseZero();
        HandleScroll();
        HandleKeyR();
        HandleKeySpace();

    }

    private void HandleMouseZero()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shotgun.FireAction();
        }
    }

    public void HandleScroll()
    {
        var scroll = Input.mouseScrollDelta.y;

        shotgun.HandleForearmAction(scroll);
    }

    public void HandleKeySpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotgun.HandleReloadAction();
        }
    }

    public void HandleKeyR()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            shotgun.ToggleReloadState();
        }
    }
}
