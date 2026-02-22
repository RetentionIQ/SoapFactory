using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandmadeSoap : Product
{
    public override string GetProductName()
    {
        return "Handmade Soap";
    }

    public override int GetProductPrice()
    {
        return 1200;
    }

    public override int GetSellPrice()
    {
        return 20;
    }

}
