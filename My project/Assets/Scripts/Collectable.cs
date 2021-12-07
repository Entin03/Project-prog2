using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : Collidible
{
    protected bool collected;

    //Ha a coll.name a Player akkor collectedet truera állítjuk
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();
    }

    //Ha collecteltük az itemet akkor truera állítjuk
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
