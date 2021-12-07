using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D characterController;
    Rigidbody2D rgbd2;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeReference] HighlightController highlightcontroller;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();   
        rgbd2 = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

      private void Update()
  {
      Check();

      if (Input.GetMouseButtonDown(1))
      {
          Interact();
      }
  }

  private void Check()
  {
    Vector2 position = rgbd2.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

    foreach (Collider2D c in colliders)
    {
        Interactable hit = c.GetComponent<Interactable>();
        if (hit != null)
        {
            highlightcontroller.Highlight(hit.gameObject);
            return;
        }
    }
    highlightcontroller.Hide();
  }

  private void Interact()
  {
      Vector2 position = rgbd2.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

    foreach (Collider2D c in colliders)
    {
        Interactable hit = c.GetComponent<Interactable>();
        if (hit != null)
        {
            hit.Interact(character);
            break;
        }
    }
  }
}
