using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player_elo;

    void LateUpdate()
    {
        Vector3 newPosition = player_elo.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
