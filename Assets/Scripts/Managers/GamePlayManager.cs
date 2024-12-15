using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;

    public GridHandler GridHandler;

    private Card _lastSelectedCard;

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
    }

    public void GenerateGrid(SetLevelData levelData)
    {

        _lastSelectedCard = null;
        Score = 0;

        UpdateScore(Score);

        GridHandler.GenerateGrid(levelData);
    }

    public void DestroyGrid()
    {
        GridHandler.DestroyGrid();
    }

    public void OnCardButtonClick(Card card)
    {
        card.ShowCard();

        if (_lastSelectedCard == null)
        {
            // First selection: store the card and return
            card.ShowCard();
            _lastSelectedCard = card;
            return;
        }

        // Avoid comparing the same card
        if (_lastSelectedCard.gameObject == card.gameObject)
            return;

        // Check for a match
        if (_lastSelectedCard.CardIndex == card.CardIndex)
        {            
            _lastSelectedCard.DisableCard();
            card.DisableCard();

            UpdateScore();

            GridHandler.ReduceCardCount();
        }
        else
        {
            card.HideCard();
            _lastSelectedCard.HideCard();
        }

        // Reset for the next pair of selections
        _lastSelectedCard = null;
    }

    public void UpdateScore(int iScore = 1000)
    {
        Score += iScore;

        UIManager.Instance.UpdateScoreInUI(Score);
    }

    public void SaveData()
    {
        GridHandler.SaveGameJsonData();
    }

    public void LoadGame()
    {
        GridHandler.LoadSavedLevel();
    }

    public void ClearSaveData()
    {
        GridHandler.ClearSavedLevel();
    }
}
