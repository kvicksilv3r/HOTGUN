using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiStatus : MonoBehaviour
{
    public TextMeshProUGUI shotgunStatus;
    public TextMeshProUGUI chamberStatus;
    public TextMeshProUGUI ammoStatus;
    public Shotgun shotgun;

    // Update is called once per frame
    void Update()
    {
        var sgStatus = shotgun.shotgunState == ShotgunState.Reloading ? "Reload" : "Attack";
        shotgunStatus.text = $"State: {sgStatus}";

        var sgChamber = shotgun.chamberShellState.ToString();
        chamberStatus.text = $"Chamber: {sgChamber}";

        ammoStatus.text = $"Ammo: {shotgun.currentShells}/{shotgun.maxShells}";
    }
}
