using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private WindowBase[] windowPrefabs;
    private Stack<WindowBase> windows = new Stack<WindowBase>();

    public static WindowManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public WindowBase Show<T>() where T : WindowBase
    {
        foreach (WindowBase window in windowPrefabs)
        {
            if (window is T)
            {
                return CreateOrOpen(window);
            }
        }
        throw new System.ArgumentException($"Окно не добавлено в windowPrefabs: {typeof(T).Name}");
    }
    private WindowBase CreateOrOpen(WindowBase windowBase)
    {
        if (HasWindowInStack(windowBase))
        {
            return OpenWindow(windowBase);
        }
        else
        {
            return CreateWindow(windowBase);
        }
    }

    private WindowBase CreateWindow(WindowBase window)
    {
        WindowBase newWindow = Instantiate(window, transform);
        newWindow.Show();
        windows.Push(newWindow);
        return newWindow;
    }

    private WindowBase OpenWindow(WindowBase window)
    {
        foreach (WindowBase windowInStack in windows)
        {
            if (window.GetType() == windowInStack.GetType())
            {
                windowInStack.gameObject.SetActive(true);
                windowInStack.Show();
                return windowInStack;
            }
        }
        throw new System.ArgumentException("Окно не найдено");
    }
    private bool HasWindowInStack(WindowBase window)
    {
        foreach (WindowBase windowInStack in windows)
        {
            if (windowInStack.GetType() == window.GetType())
            {
                return true;
            }
        }
        return false;
    }
    private bool IsWindowOpen(WindowBase window)
    {
        if (HasWindowInStack(window))
        {
            if (window.IsWindowOpen)
            {
                return true;
            }
        }
        return false;
    }
    public bool TryGetWindow<T>(out WindowBase windowBase) where T : WindowBase
    {
        foreach (WindowBase window in windowPrefabs)
        {
            if (window is T)
            {
                windowBase = window;
                return true;
            }
        }
        windowBase = null;
        return false;
    }
    public WindowBase HideWindow<T>() where T : WindowBase
    {
        foreach (WindowBase window in windowPrefabs)
        {
            if (window is T)
            {
                return CloseWindow(window);
            }
        }
        throw new System.ArgumentException($"Окно не добавлено в windowPrefabs: {typeof(T).Name}");
    }

    public WindowBase CloseWindow(WindowBase window)
    {
        foreach (WindowBase windowInStack in windows)
        {
            if (window.GetType() == windowInStack.GetType())
            {
                windowInStack.Hide();
                return windowInStack;
            }
        }
        throw new System.ArgumentException("Окно не найдено");
    }
    public bool TryGetOpenWindow<T>(out WindowBase windowBase) where T : WindowBase
    {
        foreach (WindowBase windowInStack in windows)
        {
            if (windowInStack.GetType() == typeof(T))
            {
                windowBase = windowInStack;
                return true;
            }
        }
        windowBase = null;
        return false;
    }
}
