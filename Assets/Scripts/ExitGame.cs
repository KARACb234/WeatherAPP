using UnityEngine;
using System;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
