using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
   public Transform lookAt;

   //Milyen messze mehet a játékos x,y-ban mielőtt a kamera követni kezdi
   public float boundX = 0.15f;
   public float boundY = 0.05f;

   private void LateUpdate()
   {
       Vector3 delta = Vector3.zero;

        //Ez annak ellenőrzésére szolgál, hogy az X tengely határain belül vagyunk-e
       float deltaX = lookAt.position.x - transform.position.x;
       if (deltaX > boundX || deltaX < -boundX)
       {
           if (transform.position.x < lookAt.position.x)
           {
               delta.x = deltaX - boundX;
           }
           else
           {
               delta.x = deltaX + boundX;
           }
       }

         //Ez annak ellenőrzésére szolgál, hogy az Y tengely határain belül vagyunk-e
       float deltaY = lookAt.position.y - transform.position.y;
       if (deltaY > boundY || deltaY < -boundY)
       {
           if (transform.position.y < lookAt.position.y)
           {
               delta.y = deltaY - boundY;
           }
           else
           {
               delta.y = deltaY + boundY;
           }
       }

       transform.position += new Vector3(delta.x, delta.y, 0);
   }
}   
     