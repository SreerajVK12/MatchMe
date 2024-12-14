using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGroupHandler : MonoBehaviour
{
    public GameObject LevelPrefab;

    private ToggleGroup _toggleGroup;

    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
    }

    public void GenerateLevelData()
    {
        foreach (var level in DataManager.Instance.DataSource.LevelObjects)
        {
            var newLevel = Instantiate(LevelPrefab);
            newLevel.GetComponent<SetLevelData>().SetRowColumnCount(level.rowCount, level.columnCount);
            newLevel.GetComponent<SetLevelData>().SetSpacingAndPadding(level.spacing, level.Padding);
            newLevel.GetComponent<Toggle>().group = _toggleGroup;
            newLevel.gameObject.transform.SetParent(transform);
        }
    }
}
