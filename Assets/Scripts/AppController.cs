using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    private void Start()
    {
        WindowManager.Instance.Show<WelcomeWindow>();
    }
}
