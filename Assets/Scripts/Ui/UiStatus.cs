using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiStatus : MonoBehaviour
{
    public TextMeshProUGUI shotgunStatus;
    public TextMeshProUGUI chamberStatus;
    public TextMeshProUGUI ammoStatus;

    public TextMeshProUGUI pickupText;

    public Shotgun shotgun;

    public static UiStatus Instance;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var sgStatus = shotgun.shotgunState == ShotgunState.Reloading ? "Reload" : "Attack";
        shotgunStatus.text = $"State: {sgStatus}";

        var sgChamber = shotgun.chamberShellState.ToString();
        chamberStatus.text = $"Chamber: {sgChamber}";

        ammoStatus.text = $"Ammo: {shotgun.currentShells}/{shotgun.maxShells}";
    }

    public void DisplayPickup(string pickupName)
    {
        pickupText.text = $"[E] {pickupName}";
    }

    public void HidePickup()
    {
        pickupText.text = "";
    }
}
