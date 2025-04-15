using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(CanvasGroup))]
public class WindowBase : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private const float SHOW_DURATION = 1;
    private bool _isWindowOpen;
    public bool IsWindowOpen => _isWindowOpen;
    private void Awake()
    {
    }
    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }
    public virtual void Show()
    {
        _canvasGroup.DOFade(1, SHOW_DURATION);
        _isWindowOpen = true;
    }
    public virtual void Hide()
    {
        _isWindowOpen = false;
        _canvasGroup.DOFade(0, SHOW_DURATION);
    }
}
