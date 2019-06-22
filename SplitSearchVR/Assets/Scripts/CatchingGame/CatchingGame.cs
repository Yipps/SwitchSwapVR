using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingGame : MonoBehaviour
{
    //Singleton instance
    public static CatchingGame instance;

    //Script will reference gameobjects and turn on gravity
    public List<GameObject> fallingObjects;

    //Rules of the game
    public int numCatchesToWin = 2;
    
    internal int numCaughtObjects = 0;
    internal int numOfDroppedObjects = 0;

    private void Awake()
    {
        instance = this;
    }

    public void ObjectHitFloor()
    {
        numOfDroppedObjects++;
        CheckGameWinLose();
    }

    public void ObjectCaught()
    {
        numCaughtObjects++;
        CheckGameWinLose();
    }

    public void CheckGameWinLose()
    {
        if (numCaughtObjects >= numCatchesToWin)
        {
            //You caught enough objects to win. Call win function
        }

        if (numOfDroppedObjects > fallingObjects.Count - numCatchesToWin)
        {
            //To many objects are dropped. Call lose function

        }
    }

    public void DropAllObjects()
    {
        foreach(GameObject fallingObject in fallingObjects)
        {
            fallingObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
