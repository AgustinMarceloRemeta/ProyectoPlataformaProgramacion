using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour
{
    public float Speed, SpeedUp;
    protected bool Grounded= true;
    protected Rigidbody2D rb;
    float Speed2;
    [SerializeField] LayerMask Layer;
    [SerializeField] string Tag1, Tag2;



    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Update()
    {
        mov();
        isGrounded();
    }
    void mov()
    {
        float InputX = Input.GetAxis("Horizontal");
       
        Vector3 Movement = new Vector3(InputX, 0 , 0);
        transform.Translate(Movement * Speed2 * Time.deltaTime);
        if ((Input.GetKey("space") || Input.GetKeyDown("w")) && Grounded)
        {
            rb.AddRelativeForce(new Vector2(0, SpeedUp), ForceMode2D.Impulse);
            Grounded = false;
        }
        if (Input.GetKeyDown("a")) 
        { transform.rotation =  Quaternion.Euler(0,180f, 0);
            Speed2 = -Speed;
        }
        if (Input.GetKeyDown("d")) 
        { transform.rotation = Quaternion.Euler(0, 0, 0);
            Speed2 = Speed;
        }
    }
    void isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, Layer.value);
        if (hit) Grounded = true;
        else Grounded = false;
    }
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tag1)) Dead();
        if (collision.collider.CompareTag(Tag2)) Dead();
    }
}
