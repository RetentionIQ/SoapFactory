using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAccuracyUpgrade : Upgrade
{
    private int upgradePrice = 150;

    public override string GetUpgradeName()
    {
        return "Improve Accuracy";
    }

    public override int GetUpgradePrice()
    {
        return upgradePrice;
    }

    public override void TakeAction()
    {
        if (machine.cannonMissChance != 0 && CashManager.Instance.BuyAnUpgrade(this))
        {
            machine.BuyAccuracy();

            upgradePrice = upgradePrice * 2;

        }
        else
        {
            print($"You Need {GetUpgradePrice()}!");
        }
    }
}
