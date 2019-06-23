using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    // Start is called before the first frame update
	public BalanceMicroManager cmm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
    	if(col.tag == "Box"){
    		Debug.Log("Whoops");
    		cmm.OnBoxTouchedGround();
    		Destroy(col.gameObject);
    	}
    }
}
