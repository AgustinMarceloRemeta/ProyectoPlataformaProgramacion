using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harts : MonoBehaviour
{
    [SerializeField] Sprite Sp1, Sp2;
     public int life = 2;

    private void ChangeSp()
    {
        if (life == 2) GetComponent<SpriteRenderer>().sprite = Sp1;
        if (life == 1) GetComponent<SpriteRenderer>().sprite = Sp2;
        if (life == 0) gameObject.SetActive(false);
    }
}
