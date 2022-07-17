using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameObject _inventoryGrid;
    private static GameObject _selectedObject;
    public List<GameObject> spawnPoints = new List<GameObject>();
    private List<GameObject> _prefabOnScene = new List<GameObject>();
    private static UIGame uiGame;
    public DropSystem dropSystem;

    private void Start()
    {
        uiGame = GameObject.Find("GameUI").GetComponent<UIGame>();
    }
    public void CloseInventory()
    {
        gameObject.SetActive(false);
        _gameLogic.gameInProgerss = true;
        Time.timeScale = 1.0f;
    }
    public void SelectItem()
    {
        foreach(var card in uiGame.GetComponent<UIGame>().cardInInventory)
        {
            if (card.transform.Find("Back").GetComponent<Outline>().enabled)
            {
                card.transform.Find("Back").GetComponent<Outline>().enabled = false;
            }
        }
        EventSystem.current.currentSelectedGameObject.transform.Find("Back").GetComponent<Outline>().enabled = true;
        _selectedObject = EventSystem.current.currentSelectedGameObject;
    }
    public void AcceptSelect()
    {
        DropItemOnBoard();
    }
    public void Refresh()
    {

    }
    private void DropItemOnBoard()
    {
        foreach (var item in dropSystem.items)
        {
            if ((_selectedObject.transform.Find("Mask").transform.Find("ImageCard").GetComponent<Image>().sprite == item.Icon) &&
                (!_selectedObject.GetComponent<StateObject>().isActive))
            {
                foreach (var spawnPoint in spawnPoints)
                {
                    if (!spawnPoint.GetComponent<StateObject>().isActive)
                    {
                        GameObject itemClone = (GameObject)Instantiate(item.Prefab, spawnPoint.transform);
                        _prefabOnScene.Add(itemClone);
                        _gameLogic.playerDamage += Convert.ToInt32(item.Power);
                        _selectedObject.GetComponent<StateObject>().isActive = true;
                        spawnPoint.GetComponent<StateObject>().isActive = true;
                        break;
                    }
                }
            }
        }
    }
    public void RefreshGameBoard()
    {
        foreach (Transform card in _inventoryGrid.transform)
        {
            if(card.GetComponent<StateObject>().isActive)   
               card.GetComponent<StateObject>().isActive = false;
        }
        foreach (var pref in _prefabOnScene)
        {
            Destroy(pref);
        }
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.GetComponent<StateObject>().isActive = false;
        }
    }
}