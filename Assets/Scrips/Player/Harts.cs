using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harts : MonoBehaviour
{
    [SerializeField] Sprite[] Sprites;
     public int life = 2;

    public void ManagerHarts()
    {
        life--;
        for (int i = 0; i < Sprites.Length; i++)
        {
            if(life == i)
            {
                GetComponent<SpriteRenderer>().sprite = Sprites[i];
            }
        }
    }
}
