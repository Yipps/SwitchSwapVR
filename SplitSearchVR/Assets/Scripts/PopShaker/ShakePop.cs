using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject progressBar;
    public TMPro.TextMeshProUGUI _percentComplete;

    public ParticleSystem success;
    public ParticleSystem failure;

    public AudioSource shakingSound;
    public AudioSource geyser;

    // Start is called before the first frame update
    private void Start()
    {
        success.Pause();
        failure.Pause();

        //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }

    // Update is called once per frame
    void Update()
    {

        OVRInput.SetControllerVibration(1, totalShakeValue / 500, OVRInput.Controller.RTouch);

        //Change in soda positions between last frame and current frame
        deltaSodaPosition = LastSodaPosition - _Hand.transform.position;
        _percentComplete.text = (totalShakeValue / 5) + "%";

        //Debugging console log to verify totalshakevalue
        print("Total shjake value: " + totalShakeValue);


        //If the shaking force is greater than shakeForceMin, increase totalShakeValue by shakeIncreaseAmount
        if (deltaSodaPosition.magnitude > shakeForceMin)
        {
            print("Now we're shaking!");
            if (shakingSound.isPlaying == false)
            {
                shakingSound.Play();
            }



            //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            totalShakeValue += shakeIncreaseAmount;
            progressBar.transform.localScale += new Vector3(.01f, 0, 0);
        }

        //Console debug to verify magnitude is being registered
        //print(deltaSodaPosition.magnitude);

        //Record value of current frame to compare to next frame
        LastSodaPosition = _Hand.transform.position;
    }


    //Evaluates whether the player shook the can enough
    public void EvaluateShaking()
    {
        print("Total shake value: " +totalShakeValue);
        //If they shook it greater than the threshold they win
        if (totalShakeValue > shakeThreshold)
        {
            //todo trigger win animation
            print("You win!");
            success.Play();
            geyser.Play();
            GameManager.Instance.SetWinCondition(true);
        }
        //Otherwise, they lose
        else
        {
            //todo trigger lose animation
            print("You lose!");
            failure.Play();
            geyser.Play();
            geyser.volume = .5f;

            GameManager.Instance.SetWinCondition(false);
            GetComponentInChildren<ParticleSystem>().enableEmission = true;
        }
    }

    public void Eruption()
    {
        
    }
}
