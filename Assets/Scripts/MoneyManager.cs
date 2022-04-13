using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneyText;

    private void Start() 
    {
        moneyText.text = money.ToString();
    }
    public void EarnMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            moneyText.text = money.ToString();
        }
        else
        {
            NotEnoughMoney();
        }
    }

    private void NotEnoughMoney()
    {
        //do something like popup
        Debug.Log("Money is not enough");
    }
}
