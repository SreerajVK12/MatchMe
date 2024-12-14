using TMPro;
using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.Instance.PlayOneShot(Sounds.GameOver);
    }

    public void OnClickOfHomeButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.HOME);

        Debug.Log("OnClickOfHomeButton");
    }
}