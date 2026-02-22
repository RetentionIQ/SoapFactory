using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentedSoap : Product
{
    public override int GetProductPrice()
    {
        return 600;
    }

    public override string GetProductName()
    {
        return "Scented Soap";
    }

    public override int GetSellPrice()
    {
        return 15;
    }
}
