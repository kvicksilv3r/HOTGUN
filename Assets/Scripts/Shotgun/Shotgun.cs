using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Shotgun : MonoBehaviour
{
    [Header("Ammo")]
    public int maxShells;

    [SerializeField]
    public int currentShells;

    public bool hasSlamShooting = false;

    public StrikerStatus strikerStatus = StrikerStatus.Uncocked;

    public ShotgunState shotgunState = ShotgunState.Empty;
    public ShotgunState lastState;

    public ForearmState forearmState = ForearmState.Forward;
    public ForearmState lastForearmState;

    public ChamberShellState chamberShellState = ChamberShellState.Empty;

    private ShotgunSoundManager shotgunAudio;

    public UnityEvent e_shoot;

    private Player player;

    public bool IsReloading => shotgunState == ShotgunState.Reloading;

    public static Shotgun Instance;

    /// <summary>
    /// Reload when forearm slide is in forward position
    /// Cocking will always be true    /// 
    /// </summary>
    /// 

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        player = Player.Instance;
        shotgunAudio = ShotgunSoundManager.Instance;
        InitShotgun();
    }

    public void InitShotgun()
    {
        shotgunState = ShotgunState.Empty;
        strikerStatus = StrikerStatus.Uncocked;

        SetMaxShells();
        SetCurrentShells();

        CheckStartShellInChamber();
    }

    private void SetCurrentShells()
    {
        if (!HasShotgun())
        {
            return;
        }

        CheckStartLoaded();
    }

    private void SetMaxShells()
    {
        if (!HasShotgun())
        {
            maxShells = 0;
            return;
        }

        maxShells = player.equippedShotgun.maxShells;
    }

    private void CheckStartShellInChamber()
    {
        if (HasShotgun() && player.equippedShotgun.startShellInChamber)
        {
            chamberShellState = ChamberShellState.Primed;
        }
    }

    private void CheckStartLoaded()
    {
        if (HasShotgun() && player.equippedShotgun.startLoaded)
        {
            currentShells = maxShells;
            shotgunState = ShotgunState.Loaded;
            strikerStatus = StrikerStatus.Cocked;
        }
    }

    public void FireAction()
    {
        if (!HasShotgun())
        {
            return;
        }

        PullTrigger();
    }

    public void HandleForearmAction(float scroll)
    {
        if (!HasShotgun())
        {
            return;
        }

        if (scroll > 0)
        {
            PullForearmForward();
            return;
        }

        if (scroll < 0)
        {
            PullForearmBack();
        }
    }

    public void HandleReloadToggle()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleReloadState();
        }
    }

    public void HandleReloadAction()
    {
        if (!HasShotgun())
        {
            return;
        }

        TryReload();
    }

    public void ToggleReloadState()
    {
        if (!HasShotgun())
        {
            return;
        }

        if (shotgunState == ShotgunState.Reloading)
        {
            if (currentShells > 0)
            {
                shotgunState = ShotgunState.Loaded;
            }
            else
            {
                shotgunState = ShotgunState.Empty;
            }
        }

        else
        {
            shotgunState = ShotgunState.Reloading;
        }
    }

    private void TryReload()
    {
        if (shotgunState != ShotgunState.Reloading)
        {
            return;
        }

        if (currentShells >= maxShells)
        {
            print("Shotgun full");
            return;
        }

        InsertShell();
    }

    private void InsertShell()
    {
        ShotgunVisual.Instance.Reload();
        shotgunAudio.InsertShell();
        currentShells++;
    }

    private void PullTrigger()
    {
        if (forearmState == ForearmState.Back)
        {
            return;
        }

        if (shotgunState == ShotgunState.Reloading)
        {
            return;
        }

        if (strikerStatus == StrikerStatus.Uncocked)
        {
            return;
        }

        strikerStatus = StrikerStatus.Uncocked;

        if (chamberShellState == ChamberShellState.Primed)
        {
            FireGun();
            return;
        }

        else
        {
            shotgunAudio.DryFire();
        }
    }

    public void PullForearmForward()
    {
        if (shotgunState == ShotgunState.Reloading)
        {
            return;
        }

        print("Forearm FORWARD");

        if (lastForearmState == ForearmState.Back)
        {
            strikerStatus = StrikerStatus.Cocked;
        }

        if (forearmState == ForearmState.Forward)
        {
            return;
        }

        forearmState = ForearmState.Forward;
        lastForearmState = forearmState;

        if (currentShells > 0)
        {
            currentShells--;
            chamberShellState = ChamberShellState.Primed;
            shotgunAudio.ArmForwardWithShell();
        }

        else
        {
            shotgunAudio.ArmForward();
        }
    }

    public void PullForearmBack()
    {
        if (shotgunState == ShotgunState.Reloading)
        {
            return;
        }

        print("Forearm BACK");

        if (forearmState == ForearmState.Back)
        {
            return;
        }

        if (lastForearmState == ForearmState.Back)
        {
            return;
        }

        if (chamberShellState == ChamberShellState.Primed)
        {
            //Eject intact shell
        }
        else if (chamberShellState == ChamberShellState.Spent)
        {
            //eject shell;
        }

        chamberShellState = ChamberShellState.Empty;

        forearmState = ForearmState.Back;
        lastForearmState = forearmState;

        if (currentShells > 0)
        {
            shotgunAudio.ArmBack();
        }
        else
        {
            shotgunAudio.ArmBackNoShell();
        }
    }

    private void FireGun()
    {
        chamberShellState = ChamberShellState.Spent;

        Shoot();
        e_shoot.Invoke();
    }

    private void Shoot()
    {
        print("BANG");
        shotgunAudio.Fire();
        //Shoot bullet 
        //Vfx
    }

    private bool HasShotgun()
    {
        return player.equippedShotgun != null;
    }
}