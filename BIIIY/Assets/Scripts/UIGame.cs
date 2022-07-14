using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _inventoryGrid;
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
    public void AddCardInInventory(Item item)
    {
        Debug.Log("Add card ");
        GameObject _cardClone = (GameObject)Instantiate(_cardPrefab, _inventoryGrid.transform);
        _cardClone.transform.Find("Mask").transform.Find("ImageCard").GetComponent<Image>().sprite = item.Icon;
    }
}
