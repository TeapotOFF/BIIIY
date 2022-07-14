using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public int IDItem;
    public string Price;
    public string Power;
    public GameObject Prefab;
}
