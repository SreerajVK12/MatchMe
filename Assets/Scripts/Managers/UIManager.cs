using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIScreens
{
    None,
    HOME,
    LAYOUTSELECTION,
    GAME,
    PAUSE,
    LEVELCOMPLETE,
}

public class UIManager : MonoBehaviour
{
    public GameObject home;
    public GameObject layout;
    public GameObject game;
    public GameObject pause;
    public GameObject complete;

    private UIScreens _activeScreen;

    private Dictionary<UIScreens, GameObject> _uiScreens;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _activeScreen = UIScreens.None;

        _uiScreens = new Dictionary<UIScreens, GameObject>();

        EnableScreen(UIScreens.HOME);
    }

    public void EnableScreen(UIScreens newScreen)
    {
        if (_activeScreen != UIScreens.None && newScreen != UIScreens.PAUSE)
        {
            DisableScreen(_activeScreen);
        }

        switch (newScreen)
        {
            case UIScreens.HOME:

                if (!_uiScreens.ContainsKey(newScreen))
                {
                    _uiScreens.Add(newScreen, home);
                }


                break;
            case UIScreens.LAYOUTSELECTION:

                if (!_uiScreens.ContainsKey(newScreen))
                {
                    _uiScreens.Add(newScreen, layout);
                }

                break;
            case UIScreens.GAME:

                if (!_uiScreens.ContainsKey(newScreen))
                {
                    _uiScreens.Add(newScreen, game);
                }
                break;
            case UIScreens.PAUSE:

                if (!_uiScreens.ContainsKey(newScreen))
                {
                    _uiScreens.Add(newScreen, pause);
                }
                break;
            case UIScreens.LEVELCOMPLETE:

                if (!_uiScreens.ContainsKey(newScreen))
                {
                    _uiScreens.Add(newScreen, complete);
                }

                break;
        }

        _uiScreens[newScreen].SetActive(true);
        _activeScreen = newScreen;
    }

    public void DisableScreen(UIScreens currentScreen)
    {
        _uiScreens[currentScreen].SetActive(false);
    }

    public void UpdateScoreInUI(int score)
    {
        if (_uiScreens.ContainsKey(UIScreens.GAME))
        {
            _uiScreens[UIScreens.GAME].GetComponent<GameUI>().UpdateScore(score);
        }
    }

    public void ShowLevelCompleteScreen()
    {
        Invoke("ShowLevelCompleteScreenWithDelay", 1f);
    }

    public void ShowLevelCompleteScreenWithDelay()
    {
        EnableScreen(UIScreens.LEVELCOMPLETE);
    }

}
