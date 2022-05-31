using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    private void Update() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("EnemyGround"));
        if (hit == true)
            hit.collider.gameObject.GetComponent<EnemyGround>().ToDie = true;

    }
}
