using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HubManager : MonoBehaviour{

	public string[] minigameNames;
	string nextLevelName;
	public float timeToLoad = 1.5f;

	public Text debugText;

    public GameObject swapText;


	void Awake(){
		GameManager.Instance.minigameNames = minigameNames;
		//GameManager.Instance.FillList();
	}

    void Start(){
        //Pick a random game:
        nextLevelName = GameManager.Instance.ChooseARandomGame();
        StartCoroutine(LoadSceneDelayed());
        debugText.text = "LIVES: " + GameManager.Instance.currentLives + " POINTS: " + GameManager.Instance.completedMinigames;
        /*
        if(Random.Range(0,100) > 50){
            debugText.text = debugText.text + "\nNOW SWAP!";   
        }
        */
        if(GameManager.Instance.minigamesPlayed > 0 && GameManager.Instance.minigamesPlayed%5 == 0){
            swapText.SetActive(true);
        }else{
            swapText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }


    IEnumerator LoadSceneDelayed(){
    	yield return new WaitForSeconds(timeToLoad);
        GameManager.Instance.currentGameState = GameState.minigame;
        SceneManager.LoadScene(nextLevelName);
        
    }
}
