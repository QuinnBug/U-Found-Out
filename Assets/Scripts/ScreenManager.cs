using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Screens
{
    NONE = -1,
    NEWS = 0,
    BLOG = 1,
    PHOTOS = 2,
    EMAILS = 3
}

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }

    public GameObject[] canvases = new GameObject[4];

    internal Screens currentActiveCanvas = Screens.NONE;
    internal Canvas activeCanvas { get { return canvases[(int)currentActiveCanvas].GetComponent<Canvas>(); } }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (GameObject go in canvases)
        {
            go.SetActive(false);
        }
    }

    internal void ChangeActiveScreen(Screens screen) 
    {
        currentActiveCanvas = screen;
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive((Screens)i == currentActiveCanvas);
        }
    }

    public void OpenScreen(int i) 
    {

        Screens screen = (Screens)i;
        if (currentActiveCanvas == Screens.NONE || screen == Screens.NONE)
        {
            ChangeActiveScreen(screen);
        }
        else
        {
            Debug.Log(currentActiveCanvas + " Screen Already Open");
        }
    }
}
