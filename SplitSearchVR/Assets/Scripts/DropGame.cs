using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGame : MicroScene{
    // Start is called before the first frame update
    
    public GameObject rod;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropRod(){
    	rod.GetComponent<Rigidbody>().isKinematic = false;
    }


    public void OnPlayerCatchesTheRod(){
    	GameManager.Instance.SetWinCondition(true);
    }

    public void OnRodTouchesTheGround(){
    	GameManager.Instance.SetWinCondition(false);
    }


}
