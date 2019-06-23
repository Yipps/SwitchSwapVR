using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleGame : MicroScene
{
    public GameObject obstacle;
    public Rigidbody controllerSpeed;
    public float speedModifier = 2;
    //private float speed;

    internal bool hasPlayerHitObstacle = false;
    private bool hasGameStarted = false;

    private void Update()
    {
        float rigidbodySpeed = controllerSpeed.velocity.magnitude;

        rigidbodySpeed *= speedModifier;

        if(rigidbodySpeed < 1 || hasPlayerHitObstacle)
        {
            rigidbodySpeed = 0;
        }

        //print(rigidbodySpeed);

        if (hasGameStarted)
            obstacle.transform.Translate(-Vector3.forward * Time.deltaTime * rigidbodySpeed);
    }

    public void StartBikeGame()
    {
        hasGameStarted = true;
    }

    
    // This is how you win
    // GameManager.Instance.SetWinCondition(true);

}
