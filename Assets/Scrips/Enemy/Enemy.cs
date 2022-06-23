using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int TouchForDead;
    protected Rigidbody Rb;
    public Sprite DeadSprite;
    public bool ToDie;
    public virtual void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }


    public virtual void Update()
    {
        if (TouchForDead == 0) Dead();    
    }

    public abstract void Mov();
    
    void Dead()
    {
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadSprite;
        Destroy(this.gameObject,5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (ToDie) TouchForDead--;
            else FindObjectOfType<GameManager>().RestLife();
        }
    }


}
