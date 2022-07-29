using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : Enemy
{
    [SerializeField] float KeyVelocity;
    public override void Update()
    {
        base.Update();
        RaycastHit2D hit;
        if (this.transform.rotation.eulerAngles.z == 0)
         hit = Physics2D.Raycast(transform.position, Vector2.left, 3f, LayerMask.GetMask("Player"));
        else
         hit = Physics2D.Raycast(transform.position, Vector2.down, 3f, LayerMask.GetMask("Player"));
        if (hit == true)
        {
            Player player = hit.collider.gameObject.GetComponent<Player>();
            if (color == player.Color && player!= null)
                ToDie = true;
        }

    }
    public override void Mov()
    {
        this.transform.Translate(new Vector3(-KeyVelocity* Time.deltaTime, 0),Space.Self);
    }
}
