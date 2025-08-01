using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Serialization;
using DG.Tweening;
using TMPro;
using System;

public class LoadImageToRawImage : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    [SerializeField]
    private TextMeshProUGUI _dowloadProgres;
    public Action DownloadComplete;
    public void Initialize(string iconId)
    {
        StartCoroutine(DownloadImageCoroutine(iconId));
    }
    void Update()
    {
        
    }
    private IEnumerator DownloadImageCoroutine(string iconId)
    {
        string imageReference = $"https://img.icons8.com/?size=100&id={iconId}&format=png&color=000000";
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageReference))
        {
            request.SendWebRequest();
            while(request.isDone == false)
            {
                _dowloadProgres.text = request.downloadProgress.ToString();
                yield return null;
            }
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"�� ���������� ��������� ��������{request.error}");
            }
            else
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                _rawImage.texture = downloadedTexture;
                _dowloadProgres.gameObject.SetActive(false);
                DownloadComplete?.Invoke();
            }
        }
    }
}
