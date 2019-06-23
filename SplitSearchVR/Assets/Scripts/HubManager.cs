using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HubManager : MonoBehaviour{

	public string[] minigameNames;
	string nextLevelName;
	public float timeToLoad = 1.5f;

	public TextMeshProUGUI debugText;


	void Awake(){
		GameManager.Instance.minigameNames = minigameNames;
		//GameManager.Instance.FillList();
	}

    void Start(){
        //Pick a random game:
        nextLevelName = GameManager.Instance.ChooseARandomGame();
        StartCoroutine(LoadSceneDelayed());
        debugText.text = "Lives: " + GameManager.Instance.currentLives + " Games: " + GameManager.Instance.completedMinigames;
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
