using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAnObject : MonoBehaviour
{
	public bool isInRange;
	public GameObject capsule;
	public DropGame dp;

    void Start()
    {
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
     	if(isInRange){
     		if(Input.GetKeyDown(KeyCode.Space)){
     			capsule.GetComponent<Rigidbody>().isKinematic = true;
     			dp.OnPlayerCatchesTheRod();
     		}
     	}
    }

    void OnTriggerEnter(Collider col){
    	
    	if(col.tag == "Rod"){
    		isInRange = true;
    		capsule = col.gameObject;
    	}
    }

    void OnTriggerExit(Collider col){
    	if(col.tag == "Rod"){
    		isInRange = false;
    		dp.OnRodTouchesTheGround();
    	}
    }
}
