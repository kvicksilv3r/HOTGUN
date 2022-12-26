using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 10;

    public ShotgunProperties equippedShotgun;

    public static Player Instance;

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

    }

    void Update()
    {

    }

    public void EquipNewShotgun(ShotgunProperties properties)
    {
        equippedShotgun = properties;

        //Shotgun manager.reset or initialize
    }


    public ShotgunProperties GetShotgun() => equippedShotgun;

}