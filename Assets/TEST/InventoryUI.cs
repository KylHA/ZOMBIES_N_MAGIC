using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
    }

    void UIUpdate()
    {
        Debug.Log("Called UI Method");
    }
}
