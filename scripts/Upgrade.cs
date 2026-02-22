using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    public Machines machine;

   

    public Sprite upgradeImage;

    public abstract string GetUpgradeName();

    public abstract int GetUpgradePrice();

    public abstract void TakeAction();

   

}
