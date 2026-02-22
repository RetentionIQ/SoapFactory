using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInventory : MonoBehaviour
{
    private Queue<Product> productsQueue = new Queue<Product>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Product product))
        {
            productsQueue.Enqueue(product);
            product.gameObject.SetActive(false);

            //productCount++; This is checked on Cannon script on the update function :  
            //Cannon.Instance.SetProjectilePrefab(product.GetProducedProduct());
            IngredientSelector.Instance.GetProductObjectPooling().Add(product);
        }
    }

    public Queue<Product> GetProductQueue()
    {
        return productsQueue;
    }

}
