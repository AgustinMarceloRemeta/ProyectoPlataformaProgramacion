using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreen : Player
{
    
    [SerializeField] float Climbing;
    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
      base.Update();
        if (IsClimb) Climb();
    }
    
    void Climb()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            animator.SetBool("Climb", true);
            this.transform.Translate(new Vector3(0, Climbing * Time.deltaTime, 0));
        }
        else if(Input.GetKey("s")|| Input.GetKey("down"))
        {
            animator.SetBool("Climb", true);
            this.transform.Translate(new Vector3(0, -Climbing * Time.deltaTime, 0));
        }
        else if (InputX != 0) animator.SetBool("Climb", true);
        else animator.SetBool("Climb", false);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Green"))
        {
            animator.SetBool("Climb-Idle", true);
            StartCoroutine("VerifGrounded");
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            IsClimb = true;
            Jumped = false;
            Downded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Green"))
        {
            animator.SetBool("Climb-Idle", false);
            animator.SetBool("Climb", false);
            rb.gravityScale = 1;
            IsClimb = false;
            Jumped = true;
            Downded = true;
        }
    }
}
