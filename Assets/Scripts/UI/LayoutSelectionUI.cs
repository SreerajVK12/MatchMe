using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutSelectionUI : MonoBehaviour
{
    public GameObject LevelGroup;
    private ToggleGroup _toggleGroup;
    private Toggle _selectedToggle;

    void Start()
    {
        var groupHandler = LevelGroup.GetComponent<LevelGroupHandler>();
        _toggleGroup = LevelGroup.GetComponent<ToggleGroup>();

        groupHandler.GenerateLevelData();

        foreach (var toggle in _toggleGroup.GetComponentsInChildren<Toggle>())
        {
            // Subscribe to the onValueChanged event
            toggle.onValueChanged.AddListener((isOn) =>
            {
                if (isOn)
                {
                    OnToggleSelected(toggle);
                }
            });
        }
    }

    void OnToggleSelected(Toggle selectedToggle)
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        _selectedToggle = selectedToggle;
    }

    public void OnClickOfPlayButton()
    {
        var levelData = _selectedToggle.gameObject.GetComponent<SetLevelData>();

        GamePlayManager.Instance.GenerateGrid(levelData);

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.GAME);
    }
}