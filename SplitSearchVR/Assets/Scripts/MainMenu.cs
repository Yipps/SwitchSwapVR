using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    // Start is called before the first frame update
    void Start()
    {
     	base.Start();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName){
    	SceneManager.LoadScene(sceneName);
    }
}
