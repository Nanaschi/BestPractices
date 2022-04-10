using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public void SaveFloatData(string dataName, float dataToSave)
    {
        print("Data is saved");
        PlayerPrefs.SetFloat(dataName, dataToSave);
    }
    
    public void LoadFloatData(string dataName, float dataToLoad)
    {
        print("Data is loaded");
        PlayerPrefs.GetFloat(dataName, dataToLoad);
    }
    
}
