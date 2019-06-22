using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private bool wasCaught;
    
    private void Start()
    {
        CatchingGame.instance.fallingObjects.Add(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object collided with a floor
        //Only count an object dropped if it wasn't caught. This handles the case if a player catches an object and later drops it on the floor
        if (collision.gameObject.tag == "Floor" && wasCaught == false)
        {
            CatchingGame.instance.ObjectCaught();
        }
    }
}
