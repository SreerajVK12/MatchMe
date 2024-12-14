using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutSelectionUI : MonoBehaviour
{
    public ToggleGroup _toggleGroup;
    public Toggle _selectedToggle;

    void Start()
    {
        //foreach (var toggle in _toggleGroup.GetComponentsInChildren<Toggle>())
        //{
        //    // Subscribe to the onValueChanged event
        //    toggle.onValueChanged.AddListener((isOn) =>
        //    {
        //        if (isOn)
        //        {
        //            OnToggleSelected(toggle);
        //        }
        //    });
        //}
    }

    void OnToggleSelected(Toggle selectedToggle)
    {
        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        _selectedToggle = selectedToggle;
    }

    public void OnClickOfPlayButton()
    {
        Debug.Log("OnClickOfPlayButton");

        Debug.Log("Selected Toggle: " + _selectedToggle.name);

        SoundManager.Instance.PlayOneShot(Sounds.Button_Click);

        UIManager.Instance.EnableScreen(UIScreens.GAME);
    }
}