using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int Health;
    public int Stamina;

    private void Update()
    {
        if (this.Health <= 0) 
        {
            DestroyImmediate(this.gameObject);
        }
    }

    public void ApplyDamage(int damage) 
    {
        Health -= damage;
    }
}
