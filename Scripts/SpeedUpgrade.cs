using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedUpgrade : Upgrade
{
    private int upgradePrice = 150;


    public override string GetUpgradeName()
    {
        return "Speed Upgrade";
    }

    public override int GetUpgradePrice()
    {
        return upgradePrice;
    }

    public override void TakeAction()
    {
        float minSpeed = .6f;
        
        if (machine.actionSpeed > minSpeed && CashManager.Instance.BuyAnUpgrade(this))

        {
            machine.BuySpeed();
            
            upgradePrice = upgradePrice *  2;


        }
        else
        {
            print($"You Need {GetUpgradePrice()}!");
        }


    }
}
