using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _iScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateScore(int score)
    {
        _iScore += score;
    }

    public int GetScore()
    {
        return _iScore;
    }

    public void ResetScore(int score = 0)
    {
        _iScore = score;
    }
}
