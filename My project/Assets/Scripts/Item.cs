using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Létrehozünk a Datában egy Item menüt ahol tudunk icont, stackblet és nevet beállítani
[CreateAssetMenu(menuName = "Data/Item")]

public class Item : ScriptableObject
{ 
    public string Name;
    public bool stackble;
    public Sprite icon;
}
