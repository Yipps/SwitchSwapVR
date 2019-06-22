using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroScene : MonoBehaviour{



    // Start is called before the first frame update
    public UnityEvent startEvents;
    //public UnityEvent gameEvent;
    public UnityEvent endEvents;

    [Tooltip("Does the player start by winning?")]
    public bool gameStateStart = false; 

    public float customGameDuration = 4.0f;

    void Start(){
        GameManager.Instance.OnIntroBegin();
        GameManager.Instance.startEvents = startEvents; 
        //GameManager.Instance.gameEvent = gameEvent; 
        GameManager.Instance.endEvents = endEvents;
        GameManager.Instance.winConditionMet = gameStateStart;
        GameManager.Instance.SetGameDuration(customGameDuration);
    }

    // Update is called once per frame
    void Update(){
        
    }

}
