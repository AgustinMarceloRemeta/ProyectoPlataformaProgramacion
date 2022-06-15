using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour, IColor
{
    //movement
    bool VerifGround = true;
    public int CantJumps;
    protected int Jumps;
    protected Rigidbody2D rb;
    [SerializeField] LayerMask Layer;
    public float Speed, SpeedUp;
    float Speed2;

    //rest
    GameManager Manager;
    [SerializeField] Colors Color;

    //animation
    [Header("Animacion")]

    private Animator animator;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Manager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }
    public virtual void Update()
    {
        mov();
        if (VerifGround)
        {
            isGrounded();
            animator.SetBool("Jump", false);
        }
        
    }
    #region Movement
    void mov()
    {
        float InputX = Input.GetAxis("Horizontal");

        if (InputX != 0 && VerifGround)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Jump", false);
        }
        else animator.SetBool("Run", false);

        Vector3 Movement = new Vector3(InputX, 0 , 0);
        transform.Translate(Movement * Speed2 * Time.deltaTime);

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && Jumps<CantJumps)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);
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

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Door door = collision.gameObject.GetComponent<Door>();
        if (door != null) 
        {
           door.ChangeZone();
        }
        if (collision.gameObject.CompareTag("Money"))
        {
            Manager.CantMoney++;
            Destroy(collision.gameObject);
        }
    }

    public string GetColor()
    {
        return Color.color;
    }
    #endregion
}
