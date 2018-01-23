using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataSerializer : MonoBehaviour {

    public static DataSerializer instance;

    public SaveData savedData;

    private void Awake()
    {
        if(DataSerializer.instance == null)
        {
            instance = this;            
        }
        else
        {
            Debug.Log("An instance of DataSerializer already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }


        savedData = LoadJsonSaveData();
        Debug.Log(savedData.flowerHealth);
    }

    public void SerializeSaveData(SaveData _data, string _fileName = " ") /////Saves _data to a .json file of name _fileName. _fileName should not include file extension.
    {
        string _path = Application.persistentDataPath;
        if(_fileName != " " && !_fileName.Contains(" ") && !_fileName.Contains("/"))
        {
            _path += "/" + _fileName + ".json";
        }
        else
        {
            _path += "/savefile.json";
            Debug.Log("Either _filename was empty or it contained a space or a /");
        }

        try
        { 
            File.WriteAllText(_path, JsonUtility.ToJson(_data, true));
        }
        catch(Exception e)
        {
            Debug.Log("Something went wrong while writing a file. Exception: " + e);
        }
    }

    public SaveData LoadJsonSaveData(string _fileName = " ") /////Returns a SaveData from the file _fileName. _fileName shouldn't include extension. default _fileName is savefile.json
    {
        SaveData _loadedSave = new SaveData();
        string _path = Application.persistentDataPath;
        if (_fileName != " " && !_fileName.Contains(" ") && !_fileName.Contains("/"))
        {
            _path += "/" + _fileName + ".json";
        }

        else
        {
            _path += "/savefile.json";
            Debug.Log("Either _filename was empty or it contained a space or a /");
        }

        try
        {
            string _loadedSaveAsString = File.ReadAllText(_path);
            _loadedSave = JsonUtility.FromJson<SaveData>(_loadedSaveAsString);
        }
        catch (Exception e)
        {
            Debug.Log("Something went wrong while reading a file. Exception: " + e);
        }

        return _loadedSave;
    }

    public void SaveGame()
    {
        SerializeSaveData(savedData);
    }

}
