using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ManagerMoney : MonoBehaviour
{

    [SerializeField] Text MoneyText;
    [SerializeField] GameObject Sound;
    int CantMoney;
    void Start()
    {
    if (SceneManager.GetActiveScene().name == "Lvl-1"&& PlayerPrefs.GetInt("Money", 0) > 0) PlayerPrefs.SetInt("Money", 0);
    CantMoney = PlayerPrefs.GetInt("Money", 0);
    MoneyText.text = CantMoney.ToString();
    }


    void Update()
    {

    }
    void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", CantMoney);
    }
    void MoneyMas()
    {
        CantMoney++;
        MoneyText.text = CantMoney.ToString();
        GameObject s= Instantiate(Sound, this.transform);
        Destroy(s, 5);
        
    }
    void OnEnable()
    {
        Money.MoneyEvent += MoneyMas;
        Door.SaveMoney += SaveMoney;
    }
    void OnDisable()
    {
        Money.MoneyEvent -= MoneyMas;
        Door.SaveMoney -= SaveMoney;
    }
}

