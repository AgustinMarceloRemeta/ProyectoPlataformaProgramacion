using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class GameManager : MonoBehaviour
{
    public static Action DieEvent;
    public static Action RestLifeEvent;
    [Header("ChangePlayer")]
   
    [SerializeField] GameObject Grey, Green, Red, Blue, Yellow;
    public GameObject PlayerActive;
    [SerializeField] Image SpPlayer;

    [Header("Life")]
    public int Life;
    [SerializeField] Harts[] harts;
    [SerializeField] GameObject sound;
     

    void Start()
    {
        PlayerActive = FindObjectOfType<Player>().gameObject;
        SpPlayer.sprite = PlayerActive.GetComponent<Player>().ColorSp;
    }

    void Update()
    {
        Colors();
        this.transform.position = PlayerActive.transform.position;
    }

    #region ChangePlayer
    void Change(GameObject PlayerNew)
    {
        Destroy(PlayerActive);
        Instantiate(PlayerNew, this.transform.position,Quaternion.identity);
        PlayerActive = FindObjectOfType<Player>().gameObject;
        SpPlayer.sprite = PlayerActive.GetComponent<Player>().ColorSp;
    }
    void Colors()
    {
        if (Input.GetKeyDown("1")) Change(Grey);
        else if (Input.GetKeyDown("2")) Change(Green);
        else if (Input.GetKeyDown("3")) Change(Red);
        else if (Input.GetKeyDown("4")) Change(Blue);
        //else if (Input.GetKeyDown("5")) Change(Yellow);
    }
    #endregion

    #region life
    void LifeVisual()
    {
         foreach (var item in harts)
         {
             if (!(item.life == 0))
             {
                // item.life--;
                item.ManagerHarts();
                 break;
             }
         }
        

    }
    public void ResetLife()
    {
        foreach (var item in harts) item.life = 2;
    }
    public void RestLife()
    {
        Life--;
       GameObject s=  Instantiate(sound, this.transform);
        Destroy(s, 5);
        LifeVisual();
        if (Life == 0) DieEvent?.Invoke();        
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        DieEvent += Die;
        RestLifeEvent += RestLife;
    }
    private void OnDisable()
    {
        DieEvent -= Die;
        RestLifeEvent -= RestLife;
    }

    #endregion

}
