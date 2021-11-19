using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Búza : Collactable
{
    public Sprite empty;
    public int Buza = 1;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty;
            Debug.Log("Buza");
        }
    }


}
