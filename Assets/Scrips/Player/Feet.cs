using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    [SerializeField] Colors color;
    private void Update() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("EnemyGround"));
        if (hit == true)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            if(color == enemy.color)
            enemy.ToDie = true;
        }

    }
}
