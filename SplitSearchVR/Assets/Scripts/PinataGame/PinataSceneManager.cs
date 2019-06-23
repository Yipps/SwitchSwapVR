using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataSceneManager : MicroScene
{
    public void OnSuccess()
    {
        GameManager.Instance.SetWinCondition(true);
    }


}
