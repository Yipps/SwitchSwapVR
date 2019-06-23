using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState{minigame,hub};
public class GameManager : Singleton<GameManager>{


	public TextMeshProUGUI countdouwnTimerText;

	public float gameDuration;
	public float timeToBegin = 3.0f;
	public float timeToEndGame = 3.0f;
	public string hubName = "MinigameHub";

	public string hint;

	public bool winConditionMet = false;


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
    public int completedMinigames;
    public GameState currentGameState;
    public int minigamesPlayed = 0;

    public Text timerText;

    [Header("Minigames ")]

    //Filled from hubmanager
    public string[] minigameNames;
    List<string> minigamesRemaining;

    float displayTime;
    bool timerIsOn;

	/*
    public int numberOfPlayers;
    int[] playerScore;
    */



    void Start(){
        //OnIntroBegin();
        currentGameState = GameState.hub;
        //Singleton already takes care of this
        //DontDestroyOnLoad(this);
        //for(int i = 0; i < )
        //Debug.Log("I have :"  + minigameNames.Length + " Games registered");
    }

    void Update(){
        if(timerIsOn && timerText != null){
            timerText.text = "" + displayTime.ToString("0.00");
            displayTime -= Time.deltaTime;
            if(displayTime <= 0){
                timerIsOn = false;
            }else{
                //timerText.text = "";

            }
        }
    }

    public void SetGameDuration(float newGameDuration){
    	gameDuration = newGameDuration;
    }

    public void SetGameEndDuration(float newGameDuration){
        timeToBegin = newGameDuration;
    }

    public void SetGameBeginDuration(float newGameDuration){
    	Debug.Log("Time to being is now: " + newGameDuration);
        timeToEndGame = newGameDuration;
    }   
     

    public void OnIntroBegin(){
    	Debug.Log("Time to begin is: " + timeToBegin);
        minigamesPlayed++;
    	Invoke("OnGameStart",timeToBegin);
    	currentGameState = GameState.minigame;
        gameIsComplete = false;
        displayTime = timeToBegin;
        if(timerText != null){
            Debug.Log("NAME:" + timerText.gameObject.transform.name);
            timerText.text = ""+timeToBegin;
        }else{
            Debug.Log("timer is null");
            timerText = GameObject.FindWithTag("TimerText").GetComponent<Text>();
        }
        timerIsOn = true;
    }

    void OnGameStart(){
    	//Debug.Log("Start your interactions here");
        Debug.Log("Game is complete is false now");
    	startEvents.Invoke();
    	StartCoroutine(GameLoop());
    }

    public void OnGameSuccess(float outroDuration = 3.0f){
        if(!gameIsComplete){
        	completedMinigames++;
            onWinEvents.Invoke();
            gameIsComplete = true;
        	OnOutroBegin();
        	Debug.Log("Game ends early: you win");
        	Invoke("OnOutroEnd",outroDuration);
        }

    }

    public void OnGameFailure(float outroDuration = 3.0f){
        if(!gameIsComplete){
        	currentLives--;

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

    	currentGameState = GameState.hub;
    	if(currentLives <= 0){
    		SceneManager.LoadScene("GameOverScene");
    	}else{
    		SceneManager.LoadScene(hubName);
    	}

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

    public void FillList(){
    	minigamesRemaining = new List<string>();
    	for(int i = 0; i < minigameNames.Length; i++){
    		minigamesRemaining.Add(minigameNames[i]);
    	}
    }

    public string ChooseARandomGame(){
    	if(minigamesRemaining == null){
    		//Game is being started
    		FillList();
    		//TODO: change this to the proper place, sometime
    		currentLives = maxLives;
            minigamesPlayed = 0;
    	}
    	if(minigamesRemaining.Count <= 0){
    		FillList();
    	}
    	int randomIndex = Random.Range(0,minigamesRemaining.Count);
    	string randomGame = minigamesRemaining[randomIndex];
    	minigamesRemaining.RemoveAt(randomIndex);

    	return randomGame;
    }

}
