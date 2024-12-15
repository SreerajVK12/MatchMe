using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GridHandler : MonoBehaviour
{
    public Transform parentObject; // Parent object in the scene for card positioning

    private GridLayoutGroup _gridLayout;
    private RectTransform _rectTransform;

    public GameObject cardPrefab; // Prefab for the cards

    private List<GameObject> generatedCards;
    private List<int> cardIndexValues;
    private List<bool> MatcheatusOnLoad;

    private int _iRemainingCards;

    private SetLevelData _selectedlevelData;

    void Start()
    {
        cardIndexValues = new List<int>();
        MatcheatusOnLoad = new List<bool>();
        generatedCards = new List<GameObject>();

        _gridLayout = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();

        DataManager.Instance.DataSource.LoadAllCardData();
    }

    private void SetGrid(SetLevelData levelData)
    {
        float cardSize = 1;

        if (_rectTransform != null)
        {
            float gridHeight = _rectTransform.rect.height;
            gridHeight = gridHeight - ((levelData.Padding * 2) + ((levelData.rowCount - 1) * levelData.Spacing));
            cardSize = gridHeight / levelData.rowCount;
        }

        if (_gridLayout != null)
        {
            _gridLayout.cellSize = new Vector2(cardSize, cardSize);
            _gridLayout.constraintCount = levelData.rowCount;
            _gridLayout.spacing = Vector2.one * levelData.Spacing;
            _gridLayout.padding.top = _gridLayout.padding.bottom = _gridLayout.padding.left = _gridLayout.padding.right = levelData.Padding;
        }
    }


    public void GenerateGrid(SetLevelData levelData, bool bSavedData = false)
    {
        int cardIndex = 0;
        _selectedlevelData = levelData;

        cardIndexValues.Clear();
        MatcheatusOnLoad.Clear();
        generatedCards.Clear();

        if (bSavedData)
        {
            GenerateCardValuesFromSavedData();
        }
        else
        {
            GenerateCardValues(levelData.rowCount, levelData.columnCount);
            Shuffle(cardIndexValues);
        }

        SetGrid(levelData);

        for (int x = 0; x < levelData.rowCount * levelData.columnCount; x++)
        {
            int iCardIndex = cardIndexValues[cardIndex];
            CardObject cardObj = DataManager.Instance.DataSource.GetCardById(iCardIndex);

            GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, parentObject);
            card.GetComponent<Card>().IsMatchedCard = MatcheatusOnLoad[cardIndex];
            card.GetComponent<Card>().SetCardData(cardObj.Id, cardObj.Icon);

            generatedCards.Add(card);
            cardIndex++;
        }

        _iRemainingCards = bSavedData ? _iRemainingCards  : cardIndex;
    }

    private void GenerateCardValues(int iRows, int iColumns)
    {
        int totalPairs = (iColumns * iRows) / 2;

        for (int i = 0; i < totalPairs; i++)
        {
            int iCardIndex = Random.Range(0, DataManager.Instance.DataSource.CardObjects.Count);

            cardIndexValues.Add(iCardIndex); // Add the first instance of the value
            cardIndexValues.Add(iCardIndex); // Add the matching pair

            MatcheatusOnLoad.Add(false);
            MatcheatusOnLoad.Add(false);
        }
    }

    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1); // Random index between 0 and i (inclusive)

            // Swap the current element with the random index
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void ReduceCardCount()
    {
        _iRemainingCards -= 2;

        if (_iRemainingCards <= 0)
        {
            UIManager.Instance.ShowLevelCompleteScreen();
        }
    }

    public void DestroyGrid()
    {
        var cards = generatedCards.ToList();

        foreach (var card in cards)
        {
            Destroy(card);
        }

        generatedCards.Clear();
    }

    public void SaveGameJsonData()
    {
        JSONObject gameData = new JSONObject();

        gameData.AddField("score", GamePlayManager.Instance.Score);
        gameData.AddField("RowCount", _selectedlevelData.rowCount);
        gameData.AddField("ColumnCount", _selectedlevelData.columnCount);
        gameData.AddField("Padding", _selectedlevelData.Padding);
        gameData.AddField("Spacing", _selectedlevelData.Spacing);

        JSONObject carddatas = new JSONObject();

        for (int i = 0; i < generatedCards.Count; i++)
        {
            JSONObject carddata = new JSONObject();
            carddata.AddField("IsMatchedCard", (bool)generatedCards[i].GetComponent<Card>().IsMatchedCard);
            carddata.AddField("CardIndex", (int)generatedCards[i].GetComponent<Card>().CardIndex);
            carddatas.SetField(i.ToString(), carddata);
        }

        gameData.SetField("carddatas", carddatas);

        SaveDataLocalManager.Instance.SetValue("GameData", gameData);
    }

    private void GenerateCardValuesFromSavedData()
    {
        JSONObject gameData = SaveDataLocalManager.Instance.GetValue("GameData");

        JSONObject carddata = (JSONObject)gameData["carddatas"];

        int iScore = (int)gameData["score"].i;
        GamePlayManager.Instance.UpdateScore(iScore);

        int rowCount = (int)gameData["RowCount"].i;
        int columnCount = (int)gameData["ColumnCount"].i;
        _iRemainingCards = rowCount * columnCount;

        for (int i = 0; i < rowCount * columnCount; i++)
        {
            JSONObject card = carddata[i.ToString()];
            bool matched = card["IsMatchedCard"].b;
            int CardIndex = (int)card["CardIndex"].i;

            cardIndexValues.Add(CardIndex);
            MatcheatusOnLoad.Add(matched);

            _iRemainingCards = matched ? _iRemainingCards -= 1 : _iRemainingCards; 
        }
    }


    public void LoadSavedLevel()
    {
        JSONObject gameData = SaveDataLocalManager.Instance.GetValue("GameData");

        if (gameData != null && !gameData.IsNull)
        {
            GamePlayManager.Instance.UpdateScore(0);
            GamePlayManager.Instance.UpdateScore((int)gameData["score"].i);

            this.gameObject.AddComponent<SetLevelData>();
            SetLevelData leveldata = this.gameObject.GetComponent<SetLevelData>();

            leveldata.rowCount = (int)gameData["RowCount"].i;
            leveldata.columnCount = (int)gameData["ColumnCount"].i;
            leveldata.Spacing = (float)gameData["Spacing"].f;
            leveldata.Padding = (int)gameData["Padding"].i;

            GenerateGrid(leveldata, true);
        }
    }

    public void ClearSavedLevel()
    {
        SaveDataLocalManager.Instance.SetValue("GameData", null);

        if (this.gameObject.GetComponent<SetLevelData>() != null)
        {
            Destroy(this.gameObject.GetComponent<SetLevelData>());
        }
    }
}
