using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    //Hogy tudjuk clearelni az itemcontainert
    public void Clear()
    {
        item = null;
        count = 0;
    }
}

//Létrehozunk a datában egy Item Containert ami scriptable lesz
[CreateAssetMenu(menuName = "Data/Item Container")]

public class ItemContainer : ScriptableObject
{   
    //Adunk egy slots listát az itemcontainerhez
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {   
        //Stackelhető itemet adunk az item containerhez
        if (item.stackble == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }else{
                itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else{
            //Nem stackelhető itemet adunk az item containerhez
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }
}
