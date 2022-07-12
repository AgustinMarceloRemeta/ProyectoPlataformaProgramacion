using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour, IColor
{
    //movement
    protected bool VerifGround = true, Downded = true, Jumped = true;
    public int CantJumps;
    protected int Jumps;
    protected Rigidbody2D rb;
    [SerializeField] LayerMask Layer;
    public float Speed, SpeedUp, SpeedDown;
    float Speed2;

    //rest
    [SerializeField] Colors Color;
    public Sprite ColorSp;

    //animation
    [Header("Animacion")]

    protected Animator animator;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Jumps = 3;
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
        float InputY = Input.GetAxis("Vertical");

        //Animations
        if (InputX != 0 && VerifGround && rb.velocity.y > -1) animator.SetBool("Run", true);
        else animator.SetBool("Run", false);
        AnimJump();

        //Jump
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")|| Input.GetKeyDown("up")) && Jumps<CantJumps && Jumped)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            animator.SetBool("Run", false);
            rb.AddRelativeForce(new Vector2(0, SpeedUp), ForceMode2D.Impulse);
           Jumps++;
            StartCoroutine("VerifGrounded");
        }

        //DownMove
        if (InputY < 0 && Downded)
        {
            rb.AddRelativeForce(new Vector2(0, -SpeedDown), ForceMode2D.Impulse);
        }

        //Horizontal Move
        Speed2 = InputX * Speed;
        if (Speed2<0)   transform.rotation =  Quaternion.Euler(0,180f, 0);
        if (Speed2> 0)  transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 Movement = new Vector3(Speed2, 0, 0);
        this.transform.Translate(Movement* Time.deltaTime,Space.World);
    }
    void isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, Layer.value);
        if (hit) Jumps = 0;  
    }
    public IEnumerator VerifGrounded()
    {
        VerifGround = false;
        yield return new WaitForSeconds(1);
        VerifGround = true;
    }
    #endregion

    public string GetColor()
    {
        return Color.color;
    }
    void AnimJump()
    {
     if(rb.velocity.y> 0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }
        if (rb.velocity.y < 0 && VerifGround == false)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
        if(rb.velocity.y == 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }
        if (VerifGround && rb.velocity.y > -1) animator.SetBool("Fall", false);
    }
}
