using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ManagerMoney : MonoBehaviour
{

    [SerializeField] Text MoneyText;
    public int CantMoney;
    void Start()
    {
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

