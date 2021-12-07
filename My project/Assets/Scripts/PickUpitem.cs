using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpitem : MonoBehaviour
{
   Transform player;
   [SerializeField] float speed = 5f;
   [SerializeField] float pickUpDistance = 1.5f;
   [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    //Beállítjuk az item számát és az item iconját
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

   private void Update()
   {
       //Magától destroyol ttl idő után
       ttl -= Time.deltaTime;
       if (ttl < 0) { Destroy(gameObject); }

       float distance = Vector3.Distance(transform.position, player.position);
       if (distance > pickUpDistance)
       {
           return;
       }

        //Az itemek mozogjanak felénk bizonyos speedel
       transform.position = Vector3.MoveTowards(
           transform.position,
           player.position,
           speed * Time.deltaTime           
       );

        //Ha a távolság az item és a karakter között 0.1f nél kisebb, akkor destroyoljuk az itemet és felvesszük
       if (distance < 0.1f)
       {
           if (GameManager.instance.inventoryContainer != null)
           {
               GameManager.instance.inventoryContainer.Add(item, count);
           }else{
               Debug.LogWarning("No inventory container attached to the gamemanager!");
           }

           Destroy(gameObject);
       }
   }
}
