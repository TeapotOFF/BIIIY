using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<int, int> dictionaryItems = new Dictionary<int, int>();
    private string _path;
    private void Start()
    {
        _path = Path.Combine(Application.dataPath, "SaveItem.json");
        LoadInventory();
    }
    public void AddInInventory(Item item)
    {
        if (dictionaryItems.ContainsKey(item.IDItem))
        {
            dictionaryItems[item.IDItem] = dictionaryItems[item.IDItem] + 1;
        }
        else
        {
            dictionaryItems.Add(item.IDItem, 1);
        }
        SaveInventory();
    }
    /*
     * json file:
     * {IDItem: int; CountItem: int}
     * 
     * use this: https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
     * 
     * comment: need wallet number and and its verification
     *
     */
    private void SaveInventory()
    {
        string json = JsonConvert.SerializeObject(dictionaryItems, Formatting.Indented);
        File.WriteAllText(_path, JsonConvert.SerializeObject(dictionaryItems));
    }
    private void LoadInventory()
    {
        string json = File.ReadAllText(_path);
        dictionaryItems = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
        ShowDictionary();
    }
    private void ShowDictionary() // test methhod. after complete inventory, delete this method
    {
        foreach (var item in dictionaryItems)
        {
            Debug.Log(item);
        }
    }
}
