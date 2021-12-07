using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{   
    //Megadjuk a gameobjecteket aminek adunk a unityn belül textúrát...
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;

    public override void Interact(Character character)
    {
        //Alapból zárva a chest, ha interactolunk akkor true lesz és ki lesz nyitva
        if(opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }
    } 
}
