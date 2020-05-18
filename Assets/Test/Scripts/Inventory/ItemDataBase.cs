using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataBase : MonoBehaviour
{
    public TextAsset textAsset;
    string jsonData;
    public GameObject Gun, Sword;
    //Transfer to Json Later!!!!
    public List<Item> items = new List<Item>();
    

    void BuildDatabase()
    {
        jsonData = textAsset.ToString();
        ItemList itemlist = JsonUtility.FromJson<ItemList>(jsonData);

        items = new List<Item>
        {
            new Item(0,"Sword","A sword",
             new Stats[] {new Stats("Power",10),new Stats("Defence",8)}
            ),
            
            ////////////////////////
            new Item(1,"Gun","A Gun",
            new Stats[] {new Stats("Power",15),new Stats("Defence",6)}
            )
        };
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
