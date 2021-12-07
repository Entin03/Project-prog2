using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
   
    public static ItemSpawnManager instance;

    public void Awake()
    {
        //Debug.Log("Jók vagyunk");
        instance = this;
    }

    [SerializeField] GameObject PickUpItemPrefab;

    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(PickUpItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpitem>().Set(item, count);
    }
}
