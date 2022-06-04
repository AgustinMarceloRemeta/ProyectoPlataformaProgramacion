using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour
{
    //movement
    bool VerifGround;
    public int CantJumps;
    protected int Jumps;
    protected Rigidbody2D rb;
    [SerializeField] LayerMask Layer;
    public float Speed, SpeedUp;
    float Speed2;

    //rest
    GameManager Manager;
    [SerializeField] string Tag1, Tag2;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();
    }
    public virtual void Update()
    {
        mov();
         if(VerifGround)isGrounded();
        
    }
    #region Movement
    void mov()
    {
        float InputX = Input.GetAxis("Horizontal");
       
        Vector3 Movement = new Vector3(InputX, 0 , 0);
        transform.Translate(Movement * Speed2 * Time.deltaTime);
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && Jumps<CantJumps)
        {
            rb.AddRelativeForce(new Vector2(0, SpeedUp), ForceMode2D.Impulse);
           Jumps++;
            StartCoroutine("VerifGrounded");
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
        if (hit) Jumps = 0;
    }
    IEnumerator VerifGrounded()
    {
        VerifGround = false;
        yield return new WaitForSeconds(1);
        VerifGround = true;
    }
    #endregion
    #region Collisions
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tag1)) Manager.RestLife();
        if (collision.collider.CompareTag(Tag2)) Manager.RestLife();
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ChangeZone")) 
        {
            collision.gameObject.GetComponent<Door>().ChangeZone(transform);
        }
        if (collision.gameObject.CompareTag("Money"))
        {
            Manager.CantMoney++;
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
