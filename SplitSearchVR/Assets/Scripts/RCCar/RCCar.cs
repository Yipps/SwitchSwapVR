using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCCar : MonoBehaviour
{
    public GameObject car;
    public Transform _RightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        Vector3 fwd = _RightHand.TransformDirection(Vector3.forward);

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {

         //   car.transform.position();

        }
    }
}
