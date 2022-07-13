using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public void CloseInventory()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
