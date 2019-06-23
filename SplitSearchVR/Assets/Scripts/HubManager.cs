using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HubManager : MonoBehaviour{

	public string[] minigameNames;
	string nextLevelName;
	public float timeToLoad = 1.5f;


	void Awake(){
		GameManager.Instance.minigameNames = minigameNames;
	}

    void Start(){
        //Pick a random game:
        nextLevelName = GameManager.Instance.ChooseARandomGame();
        StartCoroutine(LoadSceneDelayed());
    }

    // Update is called once per frame
    void Update(){
        
    }


    IEnumerator LoadSceneDelayed(){
    	yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(nextLevelName);
    }
}
