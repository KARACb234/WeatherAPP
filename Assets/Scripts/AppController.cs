using System;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using Utils;

public class AppController : MonoBehaviour
{
    private void Start()
    {
        WindowManager.Instance.Show<WelcomeWindow>();
        ImageCache.TryToLoadTexture("", TimeSpan.FromDays(5),out Texture2D myTexture);
    }
}
