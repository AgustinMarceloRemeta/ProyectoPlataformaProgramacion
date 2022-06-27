using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreen : Player
{
    bool IsClimb;
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
        if (Input.GetKey("w"))
        {
            this.transform.Translate(new Vector3(0, Climbing * Time.deltaTime, 0));
          //  rb.AddRelativeForce(new Vector2(0, Climbing*Time.deltaTime), ForceMode2D.Impulse);
        }
        else if(Input.GetKey("s"))
        {
            this.transform.Translate(new Vector3(0, -Climbing * Time.deltaTime, 0));
            // rb.AddRelativeForce(new Vector2(0, -Climbing * Time.deltaTime), ForceMode2D.Impulse);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Green"))
        {
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
            rb.gravityScale = 1;
            IsClimb = false;
            Jumped = true;
            Downded = true;
        }
    }
}
