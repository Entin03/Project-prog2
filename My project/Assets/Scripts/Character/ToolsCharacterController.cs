using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
  CharacterController2D character;
  Rigidbody2D rgbd2;
  [SerializeField] float offsetDistance = 1f;
  [SerializeField] float sizeOfInteractableArea = 1.2f;
 
  //Betöltéskor kerül meghívásra
  private void Awake(){
      character = GetComponent<CharacterController2D>();
      rgbd2 = GetComponent<Rigidbody2D>();
      
  }

  private void Update()
  {
      //Ha bal clickelünk akkor használjuk a UseToolt
      if (Input.GetMouseButtonDown(0))
      {
          UseTool();
      }
  }

  //Ha elég közel vagyunk hitelünk és breakeljük a foreachet
  private void UseTool()
  {
      Vector2 position = rgbd2.position + character.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

    foreach (Collider2D c in colliders)
    {
        ToolHit hit = c.GetComponent<ToolHit>();
        if (hit != null)
        {
            hit.Hit();
            break;
        }
    }
  }
}

