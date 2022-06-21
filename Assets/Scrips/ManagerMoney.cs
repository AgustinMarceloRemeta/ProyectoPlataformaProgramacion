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

    }


    void Update()
    {

    }
    void MoneyMas()
    {
        CantMoney++;
        MoneyText.text = CantMoney.ToString();
    }
    void OnEnable()
    {
        Money.MoneyEvent += MoneyMas;
    }
    void OnDisable()
    {
        Money.MoneyEvent -= MoneyMas;
    }
}

