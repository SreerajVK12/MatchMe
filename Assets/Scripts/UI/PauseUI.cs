using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void OnClickOfCloseButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.DisableScreen(UIScreens.PAUSE);
    }

    public void OnClickOfQuitButton()
    {
        GamePlayManager.Instance.ClearSaveData();

        GamePlayManager.Instance.DestroyGrid();

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.DisableScreen(UIScreens.GAME);
        UIManager.Instance.EnableScreen(UIScreens.HOME);
    }

    public void SaveAndQuitButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        GamePlayManager.Instance.SaveData();

        GamePlayManager.Instance.DestroyGrid();

        UIManager.Instance.DisableScreen(UIScreens.GAME);
        UIManager.Instance.EnableScreen(UIScreens.HOME);
    }
}
