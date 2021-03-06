using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _inventoryGrid;
    [SerializeField] private GameLogic _gameLogic;
    [HideInInspector] public List<GameObject> cardInInventory;
    private Object _cardPrefab;
    private void Start()
    {
        _cardPrefab = Resources.Load("Prefab/CardPrefab");
    }
    public void OpenInventory()
    {
        _inventory.SetActive(true);
        Time.timeScale = 0;
    }
    public void AddCardInInventory(StateObject item)
    {
        GameObject _cardClone = (GameObject)Instantiate(_cardPrefab, _inventoryGrid.transform);
        _cardClone.transform.Find("Mask").transform.Find("ImageCard").GetComponent<Image>().sprite = item.Icon;
        cardInInventory.Add(_cardClone);
    }
    public void AddCardInInventory(Item item)
    {
        GameObject _cardClone = (GameObject)Instantiate(_cardPrefab, _inventoryGrid.transform);
        _cardClone.transform.Find("Mask").transform.Find("ImageCard").GetComponent<Image>().sprite = item.Icon;
        cardInInventory.Add(_cardClone);
    }
    public void DeleteCardFromInventory(StateObject item){
        foreach(GameObject elem in cardInInventory){
            if (elem.GetComponent<StateObject>().id==item.id) {
                cardInInventory.Remove(elem);
                Destroy(gameObject);
                return;
                }
        }
    }
    public void PointEnter()
    {
        _gameLogic.gameInProgerss = false;
    }
}
