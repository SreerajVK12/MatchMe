using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    public GameObject resumeButton;

    private void OnEnable()
    {
        JSONObject gameData = SaveDataLocalManager.Instance.GetValue("GameData");

        if (gameData != null && !gameData.IsNull)
        {
            resumeButton.SetActive(true);
        }
        else
        {
            resumeButton.SetActive(false);
        }
    }

    public void OnClickOfStartButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.LAYOUTSELECTION);
    }

    public void OnClickOfResumeButton()
    {
        GamePlayManager.Instance.LoadGame();

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.GAME);
    }
}
