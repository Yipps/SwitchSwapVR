using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>{

    enum GameState{minigame,hub};

	public TextMeshProUGUI countdouwnTimerText;

	public float timeToBegin = 3.0f;
	public float timeToEndGame = 3.0f;
	public string hubName = "MinigameHub";

	public string hint;

	public bool winConditionMet = false;

	public float gameDuration;

    [Header("Events")]
	public UnityEvent startEvents;
	public UnityEvent gameEvent;
	public UnityEvent endEvents;
    public UnityEvent onWinEvents;
    public UnityEvent OnLoseEvents;
    

    bool gameIsComplete;
	/*
	bool currentState = false;
	bool judgingState = false;
	*/

    [Header ("Game Values")]

    public int maxLives = 3;
    public int currentLives;

    [Header("Swap Components")]

    public int numberOfPlayers;
    int[] playerScore;

    void Start(){
        //OnIntroBegin();
    }

    void Update(){
        
    }

    public void SetGameDuration(float newGameDuration = 4.0f){
    	gameDuration = newGameDuration;
    }

    public void SetGameEndDuration(float newGameDuration = 3.0f){
        timeToBegin = newGameDuration;
    }

    public void SetGameBeginDuration(float newGameDuration = 3.0f){
        timeToEndGame = newGameDuration;
    }   
     

    public void OnIntroBegin(){
    	Debug.Log("Calling On intro begin func");
    	Invoke("OnGameStart",timeToBegin);
    }

    void OnGameStart(){
    	//Debug.Log("Start your interactions here");
        Debug.Log("Game is complete is false now");
        gameIsComplete = false;
    	startEvents.Invoke();
    	StartCoroutine(GameLoop());
    }

    public void OnGameSuccess(float outroDuration = 3.0f){
        if(!gameIsComplete){
            onWinEvents.Invoke();
            gameIsComplete = true;
        	OnOutroBegin();
        	Debug.Log("Game ends early: you win");
        	Invoke("OnOutroEnd",outroDuration);
        }

    }

    public void OnGameFailure(float outroDuration = 3.0f){
        if(!gameIsComplete){
            OnLoseEvents.Invoke();
            gameIsComplete = true;
        	OnOutroBegin();
        	Debug.Log("Game ends early: you lose");
        	Invoke("OnOutroEnd",outroDuration);
        }

    }

    public void OnOutroBegin(){
    	endEvents.Invoke();
    }

    public void OnOutroEnd(){
    	//Time.timeScale = 1.0f;
    	Debug.Log("At this point the scene would end");
    	SceneManager.LoadScene(hubName);
    }

    void OnTimeRunsOut(bool winCondition){
    	if(winCondition){
    		OnGameSuccess();
    	}else{
    		OnGameFailure();
    	}
    }

    IEnumerator GameLoop(){
    	float elapsedTime = 0.0f;
    	//While the Win condition HAS NOT ben met
    	while(elapsedTime <= gameDuration){
    		elapsedTime += Time.deltaTime;

    		yield return null;
    	}
    	Debug.Log("Game ends on time;");
    	if(winConditionMet){
    		OnGameSuccess();	
    		Debug.Log("You win");
    	}else{
    		OnGameFailure();	
    		Debug.Log("You lose");
    	}
    }

    public void SetWinCondition(bool newWinCondition){
    	winConditionMet = newWinCondition;
    	StopAllCoroutines();
    	if(winConditionMet){
    		OnGameSuccess();	
    	}else{
    		OnGameFailure();	
    	}
    }

}
