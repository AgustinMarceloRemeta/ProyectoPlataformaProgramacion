using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Dead")] 
    public int TouchForDead;
    protected Rigidbody Rb;
    public Sprite DeadSprite;
    public bool ToDie;

    [Header("Mov Horizontal")]
    [Range(0, 10)]
    public float Limit;
    [SerializeField] private bool right;
    [SerializeField] private float velocity;
    protected float negative, positive;

    public virtual void Start()
    {
        negative = transform.position.x - Limit;
        positive = transform.position.x + Limit;
        Rb = GetComponent<Rigidbody>();
    }


    public virtual void Update()
    {
        if (TouchForDead == 0) Dead();
        Mov();
    }

    public abstract void Mov();
    
    void Dead()
    {
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadSprite;
        Destroy(this.gameObject,0.2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (ToDie) TouchForDead--;
            else
            {
                FindObjectOfType<GameManager>().RestLife();
                collision.gameObject.GetComponent<Player>().Damage();
            }
        }
    }
    public virtual void MovHorizontal()
    {
        transform.Translate(-velocity * Time.deltaTime, 0, 0);
        if (transform.position.x > positive) right = false;
        if (transform.position.x < negative) right = true;
        if (right) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (!right) transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
