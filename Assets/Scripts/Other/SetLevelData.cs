using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelData : MonoBehaviour
{
    public int rowCount = 2;
    public int columnCount = 2;
    public float Spacing = 20;
    public int Padding = 20;

    public Text label;

    public void SetRowColumnCount(int iRowCount, int iColumnCount)
    {
        rowCount = iRowCount;
        columnCount = iColumnCount;

        label.text = rowCount.ToString() + "X" + columnCount.ToString();
    }

    public void SetSpacingAndPadding(float spacing, int padding)
    {
        Spacing = spacing;
        Padding = padding;
    }
}
