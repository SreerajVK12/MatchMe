using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI _scoreText;

    public void OnClickOfPauseButton()
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.PAUSE);
    }

    public void UpdateScore(int iScore)
    {
        _scoreText.text = "Score : " + iScore.ToString();
    }
}
