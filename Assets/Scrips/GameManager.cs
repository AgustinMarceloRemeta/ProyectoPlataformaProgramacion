using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("ChangePlayer")]
    [SerializeField] Transform Appearance;
    [SerializeField] GameObject Grey, Green, Red, Blue, Yellow;
    public GameObject PlayerActive;

    [Header("Life")]
    public int Life;
    [SerializeField] GameObject[] harts;


    [Header("Money")]
    [SerializeField] Text MoneyText;
    public int CantMoney;

    void Start()
    {
        
    }

    void Update()
    {
        MoneyText.text = CantMoney.ToString();
        PlayerActive = GameObject.FindGameObjectWithTag("Player");
        Colors();
        Appearance.position = PlayerActive.transform.position;
    }
    #region ChangePlayer
    void Change(GameObject PlayerNew)
    {
        Destroy(PlayerActive);
        Instantiate(PlayerNew, Appearance.position,Quaternion.identity);       
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
            if (!(item.GetComponent<Harts>().life == 0))
            {
                item.GetComponent<Harts>().life--;
                break;
            }
        }
    }
    public void ResetLife()
    {
        foreach (var item in harts) item.GetComponent<Harts>().life = 2;
    }
    public void RestLife()
    {
        Life--;
        LifeVisual();
        if (Life == 0) Die();
        
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    #endregion

}
