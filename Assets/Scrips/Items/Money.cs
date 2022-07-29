using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Money : MonoBehaviour
{
    public static Action MoneyEvent;


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoneyEvent?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
