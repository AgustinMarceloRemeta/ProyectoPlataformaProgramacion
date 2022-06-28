using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float VelRotation;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, VelRotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            print("Muere");
        }
    }
}
