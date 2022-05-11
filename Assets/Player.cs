using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class Player : MonoBehaviour
{
    public float Speed, SpeedUp;
    bool Grounded= true;
    [SerializeField] Rigidbody2D rb;
    float Speed2;


    void mov()
    {
        float InputX = Input.GetAxis("Horizontal");
       
        Vector3 Movement = new Vector3(InputX, 0 , 0);
        transform.Translate(Movement * Speed2 * Time.deltaTime);
        if ((Input.GetKey("space")|| Input.GetKeyDown("w")) && Grounded)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) Grounded = true ;
    }
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public virtual void Basic()
    {
        mov();
        if (Input.GetKeyDown("r")) Dead();
    }
}
