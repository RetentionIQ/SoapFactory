using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    private List<Product> products = new List<Product>();
    private int productsAmount;

    public static InventorySystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Product product)
    {
        if(products.Count > 0)
        {
            productsAmount++;
            print(productsAmount);
            return;
        }
        products.Add(product);

    }

}
