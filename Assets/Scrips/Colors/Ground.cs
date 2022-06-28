using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    Colors Color;
    GameManager manager;
    bool Damage;
    [SerializeField] float DamageTime;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IColor icolor = collision.gameObject.GetComponent<IColor>();
        if (icolor != null)
        {
            string PlayerColor = icolor.GetColor();
            if (PlayerColor != Color.color)
            {
                Damage = true;
                StartCoroutine(RestLife(DamageTime));
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IColor icolor = collision.gameObject.GetComponent<IColor>();
        if (icolor != null) Damage = false;
    }
    IEnumerator RestLife(float TimeToDamage)
    {
        if(Damage)
        manager.RestLife();
        yield return new WaitForSeconds(TimeToDamage); 
        Coroutine coroutine = StartCoroutine(RestLife(DamageTime));
       if(!Damage)
        StopCoroutine(coroutine);
    }
}
