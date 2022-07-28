using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Dead")] 
    protected Rigidbody Rb;
    public Sprite DeadSprite;
    public bool ToDie;

    [Header("Mov Horizontal")]
    [Range(0, 10)]
    public float Limit;
    [SerializeField] private bool right;
    [SerializeField] private float velocity;
    protected float negative, positive;
    public Colors color;

    public virtual void Start()
    {
        negative = transform.position.x - Limit;
        positive = transform.position.x + Limit;
        Rb = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {     
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
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (ToDie) Dead();
            else
            {
                GameManager.RestLifeEvent?.Invoke();
                player.Damage();
            }
        }
    }
    public virtual void MovHorizontal()
    {
        this.transform.Translate(-velocity * Time.deltaTime, 0, 0);
        if (this.transform.position.x > positive) right = false;
        if (this.transform.position.x < negative) right = true;
        if (right) this.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (!right) this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
