using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creating A class for Basic needs of an item

[System.Serializable]
public class Item 
{
    public int ID;
    public string Name;
    public string Description;
    public Stats[] stats = new Stats[3];
    //Dictionary<string, int> _stats=new Dictionary<string, int>(); //No way to take from json ???

    public Item(int ID, string Name, string Description, Stats[] stats)
    {
        this.ID = ID;
        this.Name = Name;
        this.Description = Description;
        this.stats = stats;
    }

    //Constructor for copy item duplicating
    public Item(Item item)
    {
        this.ID = item.ID;
        this.Name = item.Name;
        this.Description = item.Description;
        this.stats = item.stats;
    }
}
[System.Serializable]
public class Stats
{
    public string name;
    public int value;
    public Stats() { }
    public Stats(string name,int value) 
    {
        this.name = name;
        this.value = value;
    }
}


[System.Serializable]
public class ItemList
{
    public List<Item> items = new List<Item>();
}