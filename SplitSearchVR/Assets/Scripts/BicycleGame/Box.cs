using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
	bool canBeDestroyed;

    void Start()
    {
        canBeDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDestructible(){
    	canBeDestroyed = true;
    }

    public void AttemptDestroyBox(){
    	if(canBeDestroyed){
    		GameObject.FindObjectOfType<BalanceMicroManager>().OnBoxTouchedGround();
    	}
    }

}
