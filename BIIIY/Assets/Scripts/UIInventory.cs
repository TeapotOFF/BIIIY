using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
<<<<<<< Updated upstream
    
=======
    private static GameObject _selectedObject;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public DropSystem dropSystem;
>>>>>>> Stashed changes
    public void CloseInventory()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void SelectItem()
    {
        EventSystem.current.currentSelectedGameObject.transform.Find("Back").GetComponent<Outline>().enabled = true;
        _selectedObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(_selectedObject);
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
                        _selectedObject.GetComponent<StateObject>().isActive = true;
                        spawnPoint.GetComponent<StateObject>().isActive = true;
                        break;
                    }
                }
            }
        }
    }
}