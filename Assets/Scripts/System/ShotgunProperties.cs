using UnityEngine;

[CreateAssetMenu(fileName = "New proterty", menuName = "New shotgun property")]
public class ShotgunProperties : ScriptableObject
{
    public string gunName;
    public Rarity rarity;
    public int maxShells;
    public int damage;
    public float spread;
    public int projectileCount;
    public bool startLoaded;
    public bool startShellInChamber;
    public bool slamfire;
    public GameObject shotgunVisual;
}