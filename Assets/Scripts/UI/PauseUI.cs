using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickOfCloseButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.DisableScreen(UIScreens.PAUSE);

        Debug.Log("OnClickOfCloseButton");
    }

    public void OnClickOfQuitButton()
    {
        Debug.Log("OnClickOfQuitButton");

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.DisableScreen(UIScreens.GAME);
        UIManager.Instance.EnableScreen(UIScreens.HOME);
    }

    public void SaveAndQuitButton()
    {
        Debug.Log("SaveAndQuitButton");

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.DisableScreen(UIScreens.GAME);
        UIManager.Instance.EnableScreen(UIScreens.HOME);
    }
}
