using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    None,
    Button_Click,
    CardFlip,
    FlipFail,
    FlipSucess,
    GameOver
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public AudioSource _sfxSource;

    private void Start()
    {
        DataManager.Instance.DataSource.LoadAllSounds();
    }

    public void PlayOneShot(Sounds sound)
    {
        string audioname = GetAudioName(sound);

        AudioClip audioClip = DataManager.Instance.DataSource.GetAudioByName(audioname);

        if (audioClip != null)
        {
            _sfxSource.PlayOneShot(audioClip);
        }
    }

    private string GetAudioName(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.Button_Click: return "ButtonClick";
            case Sounds.CardFlip: return "HideCard";
            case Sounds.FlipFail: return "ShowCard";
            case Sounds.FlipSucess: return "CardMatch";
            case Sounds.GameOver: return "GameOver";
            default: return "";
        }
    }
}
