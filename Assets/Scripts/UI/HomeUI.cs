using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    public GameObject resumeButton;

    private void OnEnable()
    {
    }

    public void OnClickOfStartButton()
    {
        Debug.Log("OnClickOfStartButton");

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.LAYOUTSELECTION);
    }

    public void OnClickOfResumeButton()
    {
        Debug.Log("OnClickOfResumeButton");

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.GAME);
    }
}
