using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroScene : MonoBehaviour{



    // Start is called before the first frame update
    [Header("Game Events")]
    public UnityEvent startEvents;
    [Tooltip("This always happen either way")]
    public UnityEvent endEvents;
    [Tooltip("This only happen if the player win")]
    public UnityEvent onWinEvents;
    [Tooltip("This only happen if the player loses")]
    public UnityEvent OnLoseEvents;

    /*
        This causes one of two behaviors:
            If your game is about resisiting for a set ammount of time, then set this value to true

            If your game is about completeing a goal before the time runs out, set this value to false
    */
    [Tooltip("Does the player start by winning?")]
    public bool gameStateStart = false; 

    public float customGameDuration = 4.0f;
    public float customBeginDuration = 3.0f;
    public float customEndDuration = 3.0f;

    void Awake(){

        //Setting the custom values to the manager
        GameManager.Instance.startEvents = startEvents; 
        //GameManager.Instance.gameEvent = gameEvent; 
        GameManager.Instance.endEvents = endEvents;
        GameManager.Instance.onWinEvents = onWinEvents;
        GameManager.Instance.OnLoseEvents = OnLoseEvents;
        GameManager.Instance.winConditionMet = gameStateStart;
        GameManager.Instance.gameDuration = customGameDuration;
        GameManager.Instance.timeToBegin = customBeginDuration;
        GameManager.Instance.timeToEndGame = customEndDuration;
        //TODO: Figure out why this doesnt work
        //GameManager.Instance.SetGameDuration(customGameDuration);
        //GameManager.Instance.SetGameEndDuration(customEndDuration);
        //GameManager.Instance.SetGameBeginDuration(customBeginDuration);
        GameManager.Instance.OnIntroBegin();
    }

    // Update is called once per frame
    void Update(){
        
    }

}
