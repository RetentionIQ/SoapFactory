using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : Machines
{

    [SerializeField] private ParticleSystem cashEffect;

    public override void BuyAccuracy()
    {
        throw new System.NotImplementedException();
    }

    public override void BuyPerfection()
    {
        throw new System.NotImplementedException();
    }

    public override void BuySpeed()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ProducedProduct producedProduct))
        {
            Cannon.Instance.AddProductToPool(producedProduct);

            Product ProducedProductParent = producedProduct.productParent;

            //Here you can multiplay the cash with the chance!



            int incomeToAdd = Mathf.FloorToInt(ProducedProductParent.GetSellPrice() * ProducedProductParent.GetPerfectionValue());
            cashEffect.Play();


            CashManager.Instance.AddCash(incomeToAdd);
        }
    }
}
