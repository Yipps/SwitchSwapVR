﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOther : MonoBehaviour
{
    public BicycleGame bikeGame;

    IEnumerator hitObstacle()
    {
        bikeGame.hasPlayerHitObstacle = true;
        print("HAWOIJDOAWIJDOIAWJDOIAWJIOD");
        yield return new WaitForSeconds(1f);
        bikeGame.hasPlayerHitObstacle = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            print("Trigger ");
            StartCoroutine(hitObstacle());
        }

        if (other.gameObject.tag == "end")
        {
            print("Pass!");
            GameManager.Instance.SetWinCondition(true);

            
        }
    }
}
