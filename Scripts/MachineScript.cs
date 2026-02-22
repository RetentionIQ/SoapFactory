using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineScript : Machines
{
    private List<Product> productsHolded = new List<Product>();

    private float timeBtwRun;

    private void Start()
    {
        timeBtwRun = actionSpeed;
    }

    private void Update()
    {
        if (productsHolded.Count == 0) return;

        timeBtwRun -= Time.deltaTime;

        if (timeBtwRun <= 0f)
        {
            Produce();
        }
    }

    private void Produce()
    {
        OnProductPassedEventCaller();

        var product = productsHolded[0];

        product.gameObject.SetActive(true);

        product.UpdateStateSkins();
        //InventorySystem.Instance.Add(product);
        //Add it into the inventory!
        productsHolded.RemoveAt(0);

        timeBtwRun = actionSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Product product)) return;
        if (product.passedEmployee) return;

        product.passedEmployee = true;
        product.SetState(Product.State.Produced);
        product.gameObject.SetActive(false);
        product.transform.position = new Vector3(transform.position.x, product.transform.position.y, transform.position.z);

        productsHolded.Add(product);
    }

    public override void BuySpeed()
    {
        actionSpeed -= .3f;
    }

    public override void BuyAccuracy()
    {
        throw new System.NotImplementedException();
    }

    public override void BuyPerfection()
    {
        throw new System.NotImplementedException();
    }
}
