using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataBase : MonoBehaviour
{
    public TextAsset textAsset;
    string jsonData;

    public List<GameObject> ItemObjList = new List<GameObject>();
    
    public List<Item> items = new List<Item>();

    void BuildDatabase()
    {
        jsonData = textAsset.ToString();
        ItemList itemlist = JsonUtility.FromJson<ItemList>(jsonData);

        foreach (var obj in itemlist.items)
        {
            items.Add(obj);
        }
    }


    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(Item => Item.ID == id);
    }
    public Item GetItem(string name)
    {
        return items.Find(Item => Item.Name == name);
    }
}
