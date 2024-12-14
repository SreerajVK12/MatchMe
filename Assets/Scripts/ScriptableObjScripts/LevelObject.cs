using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelObject : ScriptableObject
{
    public int rowCount = 2;
    public int columnCount = 2;
    public float spacing = 20;
    public int Padding = 20;
}
