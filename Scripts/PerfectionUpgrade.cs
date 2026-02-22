using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectionUpgrade : Upgrade
{
    private int upgradePrice = 75;

    public override string GetUpgradeName()
    {
        return "Perfection";
    }

    public override int GetUpgradePrice()
    {
        return upgradePrice;
    }

    public override void TakeAction()
    {

        if (CashManager.Instance.BuyAnUpgrade(this))
        {
            machine.BuyPerfection();

            upgradePrice = upgradePrice * 2;

        }
        else
        {
            print($"You Need {GetUpgradePrice()}!");
        }
    }
}
