using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableEntity
{
    public ShotgunProperties shotgun;

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
        shotgun = properties;

        Shotgun.Instance.InitShotgun();

        //Shotgun manager.reset or initialize
    }


    public ShotgunProperties GetShotgun() => shotgun;

}
