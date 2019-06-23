using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMicroManager : MicroScene
{
    // Start is called before the first frame update
	public GameObject cratesParent;
	public GameObject[] crates;
	int cratesLeft;
	AudioSource audiosourc;
	public AudioClip[] clips;
	public GameObject rotatingPoint;

    void Start(){
    	audiosourc = GetComponent<AudioSource>();
        cratesLeft = cratesParent.transform.childCount;
        crates = new GameObject[cratesLeft];
        for(int i = 0; i < cratesLeft; i++){
        	crates[i] = cratesParent.transform.GetChild(i).gameObject;
        }
        float randomAngle = Random.Range(0.0f,360.0f);
        rotatingPoint.transform.localEulerAngles = new Vector3(0,randomAngle,0);

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnBoxTouchedGround(){
    	Debug.Log("a box touched the ground");
    	audiosourc.PlayOneShot(clips[Random.Range(0,clips.Length)]);
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
        	crates[i].GetComponent<Box>().canBeDestroyed = true;
        }
    }
}
