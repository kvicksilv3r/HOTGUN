using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyArmIK : MonoBehaviour
{
    public LineRenderer lr;
    public Transform slidy;
    public Transform elbow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        lr.SetPosition(0, elbow.position);
        lr.SetPosition(1, slidy.position);
    }
}
