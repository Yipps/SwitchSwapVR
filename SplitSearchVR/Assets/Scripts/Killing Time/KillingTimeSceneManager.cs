using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingTimeSceneManager : MicroScene
   

{
    public Transform target;
    private Vector3 targetposition;


    public void RandomTargetPlacement()
    {

        targetposition = UnityEngine.Random.onUnitSphere * 2;
        targetposition.y = 1;
        target.position = targetposition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd * 10);
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            if (Physics.Raycast(transform.position, fwd, 3))
            {
                print("There is something in front of the object!");
                GameManager.Instance.OnGameSuccess();
                target.gameObject.SetActive (false);
            }
                

        }
        
    }
}
