using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public DataSource DataSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
