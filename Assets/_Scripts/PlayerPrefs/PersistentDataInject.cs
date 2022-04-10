using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.PlayerPrefs;
using UnityEngine;
using Zenject;

public class PersistentDataInject : MonoBehaviour
{
    private void SaveData(PlayerModel obj)
    {
        print("SaveFloatData");
        SaveFloatData("Player Model", obj.CurrentAmountOfHealth);
    }
    
    
    private void LoadData(PlayerModel obj)
    {
        print("LoadFloatData");
        LoadFloatData("Player Model", obj.CurrentAmountOfHealth);
    }
    
    

    public void SaveFloatData(string dataName, float dataToSave)
    {
        print("Data is saved");
        PlayerPrefs.SetFloat(dataName, dataToSave);
    }
    
    public float LoadFloatData(string dataName, float defaultValue)
    {
        print("Data is loaded");
        return PlayerPrefs.GetFloat(dataName, defaultValue);
    }
    
    public void DeleteAllSaves()
    {
        print("Data is deleted");
        PlayerPrefs.DeleteAll();
    }
    
}
