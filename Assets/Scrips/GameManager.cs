using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Grey, Green, Red, Blue, Yellow;
    [SerializeField] Transform Appearance;
     public GameObject PlayerActive;
    void Start()
    {
     
    }

    void Update()
    {
        Colors();
    }
  
    void Change(GameObject PlayerNew)
    {
        PlayerActive = GameObject.FindGameObjectWithTag("Player");
        Appearance.position = PlayerActive.transform.position;
        Destroy(PlayerActive);
        Instantiate(PlayerNew, Appearance.position,Quaternion.identity);       
    }
    void Colors()
    {
        if (Input.GetKeyDown("1")) Change(Grey);
        else if (Input.GetKeyDown("2")) Change(Green);
        else if (Input.GetKeyDown("3")) Change(Red);
        else if (Input.GetKeyDown("4")) Change(Blue);
        else if (Input.GetKeyDown("5")) Change(Yellow);
    }
}
