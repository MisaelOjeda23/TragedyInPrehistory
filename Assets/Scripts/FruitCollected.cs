using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison) {
        if (collison.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
