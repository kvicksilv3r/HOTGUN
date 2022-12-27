using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public ShotgunPickup pickup;
    RaycastHit hit;
    private Camera mainCam;
    public float interactDistance;
    public static PlayerInteract Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Ray r = new Ray(mainCam.transform.position, mainCam.transform.forward);

        if (Physics.Raycast(r, out hit, interactDistance))
        {
            if (hit.transform.gameObject.GetComponent<ShotgunPickup>())
            {
                pickup = hit.transform.gameObject.GetComponent<ShotgunPickup>();
                UiStatus.Instance.DisplayPickup(pickup.shotgun.gunName);
                return;
            }
            else
            {
                NoPickup();
            }
        }
        else
        {
            NoPickup();
        }
    }

    private void NoPickup()
    {
        pickup = null;
        UiStatus.Instance.HidePickup();
    }

    public void TryInteract()
    {
        if (pickup)
        {
            pickup.PickUp();
            pickup = null;
        }
    }
}
