using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    InventoryUI Ui;
    public List<Item> charItems = new List<Item>();
    public ItemDataBase itemDatabase;


    void Awake()
    {
        instance = this;
        Ui = GameObject.Find("InventoryUI").GetComponent<InventoryUI>();
    }


    //////////////////////////////////////////// For Testing
    private void Start()
    {
        // AddItemToCharbyName("Sword");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            equipWeapon();
    }
    ////////////////////////////////////////////

    public void AddItemToCharbyID(int id)
    {
        Item additem = itemDatabase.GetItem(id);
        charItems.Add(additem);
        Debug.Log("Item Added" + additem.Name);
    }

    public void AddItemToCharbyName(string name)
    {
        Item additem = itemDatabase.GetItem(name);

        if (additem != null)
        {
            charItems.Add(additem);
            Debug.Log("Item Added :" + additem.Name);
        }

        else Debug.Log("No item in this Name !");

        Ui.SendMessage("UIUpdate");
    }

    public Item CheckItemID(int id)
    {
        return charItems.Find(Item => Item.ID == id);
    }

    public Item CheckItemName(string Name)
    {
        return charItems.Find(Item => Item.Name == Name);
    }
    public void RemoveItem(int id)
    {
        Item Itemtoremove = CheckItemID(id);

        if (Itemtoremove != null)
        {
            Debug.Log("Removed item : " + Itemtoremove.Name);
            charItems.Remove(Itemtoremove);
        }
    }

    public void listCharItems()
    {
        foreach (Item item in charItems)
        {
            Debug.Log("Items : " + item.Name);
        }
    }

    ///Tempory test equip
    void equipWeapon() 
    {
        if(charItems.Contains(charItems.Find(x=>x.Name=="Gun")))
        {
            GameObject gun = Instantiate(itemDatabase.ItemObjList.Find(x => x.name == "Gun"), GameObject.Find("Holder").transform) as GameObject;
            gun.GetComponent<Collider>().enabled = false;
        }
    }
}