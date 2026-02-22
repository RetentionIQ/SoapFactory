using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSoap : Product
{
    public override int GetProductPrice()
    {
        return 0;
    }

    public override string GetProductName()
    {
        return "Base Soap";
    }

    public override int GetSellPrice()
    {
        return 10;
    }
}
