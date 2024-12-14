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
    }

    public void PlayOneShot(Sounds sound)
    {
    }
}
