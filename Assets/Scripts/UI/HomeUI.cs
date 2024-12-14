using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    public GameObject resumeButton;

    private void OnEnable()
    {
        JSONObject gameData = SaveDataLocalManager.Instance.GetValue("GameData");

        if (gameData != null && gameData.IsNull)
        {
            resumeButton.SetActive(false);
        }
        else
        {
            resumeButton.SetActive(false);
        }
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

        GamePlayManager.Instance.LoadGame();

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.GAME);
    }
}
