using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataLocalManager : MonoBehaviour
{
    public static SaveDataLocalManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public JSONObject GetValue(string key, JSONObject defaultVal = null)
    {
        string val = PlayerPrefs.GetString(key);

        if (val != null)
        {
            return new JSONObject(val);
        }

        return defaultVal;
    }

    public void SetValue(string key, JSONObject val)
    {
        if (val != null && !val.IsNull)
        {
            PlayerPrefs.SetString(key, val.ToString());
        }
        else
        {
            PlayerPrefs.SetString(key, null);
        }
    }
}
