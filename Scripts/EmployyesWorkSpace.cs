using System.Collections.Generic;
using UnityEngine;
using System;

public class EmployeesWorkSpace : Machines
{

    private List<Product> productsHolded = new List<Product>();

    public float addedChance = 0f;

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
            OnProductPassedEventCaller();
            var product = productsHolded[0];
            product.gameObject.SetActive(true);
            product.SetRandomPerfectionValue(addedChance);
            product.UpdateStateSkins();

            productsHolded.RemoveAt(0);

            timeBtwRun = actionSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Product product)) return;
        if (product.passedMachine) return;

        product.passedMachine = true;
        product.SetState(Product.State.RawSoap);
        product.gameObject.SetActive(false);
        product.transform.position = new Vector3(transform.position.x, product.transform.position.y, transform.position.z);

        productsHolded.Add(product);
    }

    public override void BuySpeed()
    {
        float timeToDecrease = .3f;
        actionSpeed -= timeToDecrease;
    }

    public override void BuyAccuracy()
    {
        throw new System.NotImplementedException();
    }

    public override void BuyPerfection()
    {
        addedChance += .1f;
    }
}
