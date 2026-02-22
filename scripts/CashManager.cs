using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CashManager : MonoBehaviour
{
    private int cash = 150;

    public static CashManager Instance { private set; get; }

    public event EventHandler<int> OnCashUpdated;

    private const string CASH_KEY = "Cash";

    private int startCash = 150;

    private void Awake()
    {
        Instance = this;
        cash = PlayerPrefs.GetInt(CASH_KEY, startCash);
    }
    
    public bool BuyAProduct(Product product)
    {

        if(PlayerPrefs.GetInt(product.GetProductName() , 0) == 1)
        {
            //Has already bought the product
            print("He already has the product!");
            return true;
        }
        else
        {
            if (cash >= product.GetProductPrice())
            {
                cash -= product.GetProductPrice();
                PlayerPrefs.SetInt(product.GetProductName(), 1);
                OnCashUpdated?.Invoke(this, cash);
                PlayerPrefs.SetInt(CASH_KEY, cash);
                print("He bought the prodcut");
                return true;
            }
            print("He doesn't have enough cash!");
        }


        return false;



    }
    public bool BuyAnUpgrade(Upgrade upgrade)
    {

        if (cash >= upgrade.GetUpgradePrice())
        {
            cash -= upgrade.GetUpgradePrice();
            OnCashUpdated?.Invoke(this, cash);
            PlayerPrefs.SetInt(CASH_KEY, cash);
            return true;
        }
        return false;



    }

    public void AddCash(int amount)
    {
        cash += amount;
        OnCashUpdated?.Invoke(this, cash);
        PlayerPrefs.SetInt(CASH_KEY, cash);


    }

    public int GetCash()
    {
        return cash;
    }

    public void SetCash(int cash)
    {
        this.cash = cash;
        OnCashUpdated?.Invoke(this, cash);
        PlayerPrefs.SetInt(CASH_KEY, cash);
    }
}
