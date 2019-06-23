using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMicroManager : MicroScene
{
    // Start is called before the first frame update
	public GameObject cratesParent;
	public GameObject[] crates;
	int cratesLeft;

    void Start()
    {
        cratesLeft = cratesParent.transform.childCount;
        crates = new GameObject[cratesLeft];
        for(int i = 0; i < cratesLeft; i++){
        	crates[i] = cratesParent.transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBoxTouchedGround(){
    	cratesLeft--;
    	if(cratesLeft == 0){
    		GameManager.Instance.OnGameFailure();
    	}
    }

    public void ActivateCrates(){
        for(int i = 0; i < cratesLeft; i++){
        	crates[i].transform.parent = null;
        }
    	for(int i = 0; i < crates.Length; i++){
        	crates[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
