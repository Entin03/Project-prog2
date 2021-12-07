using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreeCuttable : ToolHit
{   
    //Megadjuk a felvehető itemet, hogy mekkora legyen a szórása ha hiteljük
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    //Milyen itemet vegyünk el, mennyit dobjon és a száma egy dropnak
    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;

    public override void Hit()
        {
            while (dropCount > 0)
            {
                dropCount -= 1;

                //Random meg adjuk a szórást x-re és y-ra
                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread /2;
                position.y += spread * UnityEngine.Random.value - spread /2;

                //Klónozzuk az objectet és vissza adjuk
                GameObject go = Instantiate(pickUpDrop);
                go.GetComponent<PickUpitem>().Set(item, itemCountInOneDrop);
                go.transform.position = position;

               // ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
            }

            //Destroyoljuk a gameobjectet miután hiteltük
            Destroy(gameObject);
        }
}
