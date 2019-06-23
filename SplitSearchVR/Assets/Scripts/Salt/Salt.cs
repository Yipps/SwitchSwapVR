using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Salt : MonoBehaviour
{
    //Controller position
    public Transform _Hand;



    //The minimum amount of shaking force to count as a shake
    public float shakeForceMin;

    //The change in soda position from last frame to current frame
    private Vector3 deltaShakePosition;

    //Last frame's soda position
    private Vector3 LastShakePosition;

    public GameObject progressBar;
    public TMPro.TextMeshProUGUI _percentComplete;


    public ParticleSystem shake;
    public GameObject particleHolder;

    public GameObject dish1;
    public GameObject dish2;
    public GameObject dish3;

    public GameObject shakePoint;

    public bool isSeasoned;
    public int seasonedCount = 0;

    public AudioSource shakingSound;


    // Start is called before the first frame update
    private void Start()
    {
        //shake.Pause();


        //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }

    // Update is called once per frame
    void Update()
    {

        //shake.Play();


        //Change in soda positions between last frame and current frame
        deltaShakePosition = LastShakePosition - _Hand.transform.position;





        //If the shaking force is greater than shakeForceMin, increase totalShakeValue by shakeIncreaseAmount
        if (deltaShakePosition.magnitude > shakeForceMin)
        {
            if (shakingSound.isPlaying == false)
            {
                shakingSound.Play();
               
            }
            OVRInput.SetControllerVibration(.5f, .5f, OVRInput.Controller.RTouch);
            print("Now we're shaking!");
            //GameObject emitter = Instantiate(particleHolder, shakePoint.transform.position, Quaternion.identity) as GameObject;
            //shake = emitter.GetComponent<ParticleSystem>();

            //shake.Play();
            progressBar.transform.localScale += new Vector3(.33f, 0, 0);
            //Destroy(emitter);
            //Destroy(shake);
            
        }


        //Console debug to verify magnitude is being registered
        //print(deltaSodaPosition.magnitude);

        //Record value of current frame to compare to next frame
        LastShakePosition = _Hand.transform.position;

        //shake.Pause();
    }

    //Evaluates whether the player shook the can enough
    /*   public void EvaluateShaking()
       {
           print("Total shake value: " +totalShakeValue);
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

       }*/
}
