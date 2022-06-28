using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
     Door door;

    private void Start()
    {
       door= FindObjectOfType<Door>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) door.OpenDoor();
        Destroy(gameObject);
    }
}
