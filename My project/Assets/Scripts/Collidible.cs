using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent (typeof(BoxCollider2D))]       //automatikusan ad egy boxcollider2d az objecthez
public class Collidible : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxcollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void start(){
        boxcollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void update(){
        //Collision work /lista az összes ütköztetőről, amely átfedi ezt az ütközőt
        boxcollider.OverlapCollider(filter,hits);
        
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null )
                continue;

          //  Debug.Log(hits[i].name);

            OnCollide(hits[i]);

             //A tömb nincs megtisztítva, ezért magunk csináljuk
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll){
        Debug.Log(coll.name);
    }
}
 