using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using Utils;

public class LoadImageToRawImage : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    public Action DownloadComplete;
    private  TimeSpan duration = new TimeSpan( 30,0, 0, 0);
    public void Initialize(string iconId)
    {
        StartCoroutine(DownloadImageCoroutine(iconId));
    }
    private IEnumerator DownloadImageCoroutine(string URL)
    {
        string imageReference = URL;
        if (ImageCache.TryToLoadTexture(imageReference, duration, out Texture2D texture))
        {
            _rawImage.texture = texture;
        }
        else
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageReference))
            {
                request.SendWebRequest();
                while(request.isDone == false)
                {
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
                    ImageCache.SaveTexture(downloadedTexture, imageReference);
                    DownloadComplete?.Invoke();
                }
            }
        }
    }
}
