using TMPro;
using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    public TextMeshProUGUI _score;

    private void OnEnable()
    {
        SoundManager.Instance.PlayOneShot(Sounds.GameOver);

        _score.text = "Score : " + GamePlayManager.Instance.Score.ToString();
    }

    public void OnClickOfHomeButton()
    {
        GamePlayManager.Instance.DestroyGrid();

        GamePlayManager.Instance.ClearSaveData();

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.HOME);
    }
}
