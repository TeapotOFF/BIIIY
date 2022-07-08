using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private PlayerInventory _playerInventory;
    private Object _cardPrefab;
    private EnemyScript _enemyScript;
    private void Awake()
    {
        _enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        _enemyScript.dropCard += DropItem;
        _cardPrefab = Resources.Load("Prefab/DropCard");
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    private Item RandomItem()
    {
        int rnd = Random.Range(0,2);
        return items[rnd];
    }
    private void DropItem()
    {
        GameObject _cardClone = (GameObject)Instantiate(_cardPrefab);
        _cardClone.GetComponentInChildren<SpriteRenderer>().sprite = RandomItem().Icon;
        _cardClone.GetComponent<CardAction>()._thisItem = RandomItem();
        _cardClone.GetComponent<CardAction>().onItemAdd += _playerInventory.AddInInventory;
    }
}
