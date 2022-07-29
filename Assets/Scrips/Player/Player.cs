using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour, IColor
{
    //movement
    protected bool IsClimb;
    protected bool VerifGround = true, Downded = true, Jumped = true;
    public int CantJumps;
    protected int Jumps= 3;
    protected Rigidbody2D rb;
    [SerializeField] LayerMask Layer;
    public float Speed, SpeedUp, SpeedDown;
    float Speed2;
    protected float InputX, InputY;

    [Header("Damage")]
    [SerializeField] float DamageImpulse;
    [SerializeField] float TimeDamage;
    bool IsDamage= false;



    //rest
    [Header("Color")]
    public Colors Color;
    public Sprite ColorSp;
    SpriteRenderer Render;

    //animation
    [Header("Animacion")]

    protected Animator animator;
    [SerializeField] GameObject Sound; 

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Render = GetComponent<SpriteRenderer>();
    }

    public virtual void Update()
    {
        AnimDamage();
        mov();
        Inputs();
    }

    #region Movement
    void mov()
    {
        //Animations
        if (InputX != 0 && VerifGround && rb.velocity.y > -1) animator.SetBool("Run", true);
        else animator.SetBool("Run", false);
        AnimJump();

        //Jump
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")|| Input.GetKeyDown("up")) && Jumps<CantJumps && Jumped)
        {
            GameObject s =Instantiate(Sound, this.transform);
            Destroy(s, 5);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            animator.SetBool("Run", false);
            rb.AddRelativeForce(new Vector2(0, SpeedUp), ForceMode2D.Impulse);
           Jumps++;
            StartCoroutine("VerifGrounded");
        }
        if (VerifGround)
        {
            isGrounded();
            animator.SetBool("Jump", false);
        }

        //DownMove
        if (InputY < 0 && Downded)
        {
            rb.AddRelativeForce(new Vector2(0, -SpeedDown), ForceMode2D.Impulse);
        }

        //Horizontal Move
        Speed2 = InputX * Speed;
        if (Speed2<0)   this.transform.rotation =  Quaternion.Euler(0,180f, 0);
        if (Speed2> 0)  this.transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 Movement = new Vector3(Speed2, 0, 0);
        this.transform.Translate(Movement* Time.deltaTime,Space.World);
    }
    void isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1f, Layer.value);
        if (hit) Jumps = 0;  
    }
    public IEnumerator VerifGrounded()
    {
        VerifGround = false;
        yield return new WaitForSeconds(1);
        VerifGround = true;
    }
    void AnimJump()
    {
        if (rb.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }
        if (rb.velocity.y < 0)
        {
            if (rb.velocity.y > -1) animator.SetBool("Fall", false);
            else
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", true);
            }
        }
        if (rb.velocity.y == 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }
    }
    private void Inputs()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
    }
    #endregion

    #region Damage
    public void Damage()
    {
        if (!IsClimb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            if (this.transform.rotation.eulerAngles.y == 0)
                rb.AddRelativeForce(new Vector2(-DamageImpulse * Time.deltaTime, DamageImpulse * Time.deltaTime), ForceMode2D.Force);
            else
                rb.AddRelativeForce(new Vector2(DamageImpulse * Time.deltaTime, DamageImpulse * Time.deltaTime), ForceMode2D.Force);
        }
        StartCoroutine("DamageAnim");
        
    }
    private void AnimDamage()
    {
        if (IsDamage)
        {
            Render.enabled = !Render.enabled;
        }
    }
    IEnumerator DamageAnim()
    {
        IsDamage = true;
        yield return new WaitForSeconds(TimeDamage);
        IsDamage = false;
        Render.enabled = true;
    }
    #endregion

    public string GetColor()
    {
        return Color.color;
    }
}
