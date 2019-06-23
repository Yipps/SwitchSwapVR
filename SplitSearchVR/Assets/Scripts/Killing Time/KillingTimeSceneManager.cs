﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingTimeSceneManager : MicroScene
{
    public Transform target;
    public Transform _RightHand;
    private Vector3 targetposition;


    public void RandomTargetPlacement()
    {

        //targetposition = UnityEngine.Random.onUnitSphere * 2;
        float angle = Mathf.PI * 2f;
        targetposition = new Vector3(Mathf.Cos(angle) * 4, 1, Mathf.Sin(angle) * 4);
        target.position = targetposition;
        target.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        Vector3 fwd = _RightHand.TransformDirection(Vector3.forward);

        Debug.DrawRay(_RightHand.position, fwd * 10);
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("Press Trigger Button");
            if (Physics.Raycast(_RightHand.position, fwd, 100))
            {
                print("There is something in front of the object!");
                GameManager.Instance.SetWinCondition(true);
                GameManager.Instance.OnGameSuccess();
                target.gameObject.SetActive (false);
            }
                

        }
        
    }
}
