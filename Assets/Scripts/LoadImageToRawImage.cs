using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Serialization;
using DG.Tweening;
using TMPro;

public class LoadImageToRawImage : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    private CityElement _cityElement;
    [SerializeField]
    private TextMeshProUGUI _dowloadProgres;
    void Start()
    {
        _cityElement = GetComponentInParent<CityElement>();
        StartCoroutine(DownloadImageCoroutine(_cityElement.CityIconId));
    }
    void Update()
    {
        
    }
    private IEnumerator DownloadImageCoroutine(string iconId)
    {
        string imageReference = $"https://i.pinimg.com/originals/4b/22/96/4b22966db450e1a77d19fc7ab07cf930.jpg";
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageReference))
        {
            request.SendWebRequest();
            while(request.isDone == false)
            {
                _dowloadProgres.text = request.downloadProgress.ToString();
                Debug.Log(request.downloadProgress);
                yield return null;
            }
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"НЕ получилось загрузить картинку{request.error}");
            }
            else
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                _rawImage.texture = downloadedTexture;
                _dowloadProgres.gameObject.SetActive(false);
            }
           
        }
    }
}
