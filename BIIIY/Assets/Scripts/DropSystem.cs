using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropSystem : MonoBehaviour
{
    private GameObject _dropUI;
    private UIGame _uiGame;
    public List<Item> items = new List<Item>();
    private PlayerInventory _playerInventory;
    private Object _cardPrefab;
    private EnemyScript _enemyScript;
    private void Awake()
    {
        _dropUI = GameObject.Find("DropCardCanvas");
        _uiGame = GameObject.Find("GameUI").GetComponent<UIGame>(); 
        _enemyScript = this.gameObject.GetComponent<EnemyScript>();
        _enemyScript.dropCard += DropItem;
        _cardPrefab = Resources.Load("Prefab/CardPrefab 1");
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    private Item RandomItem()
    {
        int rnd = Random.Range(0,2);
        return items[rnd];
    }
    private void DropItem()
    {
        GameObject _cardClone = (GameObject)Instantiate(_cardPrefab, _dropUI.transform);
        _cardClone.GetComponent<CardAction>()._thisItem = RandomItem();
        _cardClone.transform.Find("Mask").transform.Find("ImageCard").GetComponent<Image>().sprite = _cardClone.GetComponent<CardAction>()._thisItem.Icon;
        //_cardClone.GetComponent<CardAction>().onItemAdd += _playerInventory.AddInInventory;
        _cardClone.GetComponent<CardAction>().onItemAdd += _uiGame.AddCardInInventory;
    }
}
