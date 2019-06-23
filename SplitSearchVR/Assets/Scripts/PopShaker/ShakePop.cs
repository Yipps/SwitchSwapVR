using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePop : MonoBehaviour
{
    //Controller position
    public Transform _Hand;

    //Total shake value, increases everytime the soda is shaken
    private float totalShakeValue;

    //Increase the shake value by shakeIncreaseAmount everytime the soda is shaken
    public float shakeIncreaseAmount;

    //If the player can increase totalShakeValue is greater than shakeThreshold before time is up, player succeeds
    public float shakeThreshold;

    //The minimum amount of shaking force to count as a shake
    public float shakeForceMin;

    //The change in soda position from last frame to current frame
    private Vector3 deltaSodaPosition;

    //Last frame's soda position
    private Vector3 LastSodaPosition;

    public ParticleSystem success;
    public ParticleSystem failure;

    // Start is called before the first frame update
    private void Start()
    {
        success.Pause();
        failure.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        //Change in soda positions between last frame and current frame
        deltaSodaPosition = LastSodaPosition - _Hand.transform.position;
        //Debugging console log to verify change is being registered
        print("Change in position: " + deltaSodaPosition + "\nMagnitude: " + deltaSodaPosition.magnitude);

        //If the shaking force is greater than shakeForceMin, increase totalShakeValue by shakeIncreaseAmount
        if (deltaSodaPosition.magnitude > shakeForceMin)
        {
            print("Now we're shaking!");
            totalShakeValue += shakeIncreaseAmount;
        }

        //Console debug to verify magnitude is being registered
        print(deltaSodaPosition.magnitude);

        //Record value of current frame to compare to next frame
        LastSodaPosition = _Hand.transform.position;
    }


    //Evaluates whether the player shook the can enough
    public void EvaluateShaking()
    {
        //If they shook it greater than the threshold they win
        if (totalShakeValue > shakeThreshold)
        {
            //todo trigger win animation
            print("You win!");
            success.Play();
            GameManager.Instance.SetWinCondition(true);
        }
        //Otherwise, they lose
        else
        {
            //todo trigger lose animation
            print("You lose!");
            failure.Play();
            GameManager.Instance.SetWinCondition(false);
            GetComponentInChildren<ParticleSystem>().enableEmission = true;
        }
    }

    public void Eruption()
    {
        
    }
}
