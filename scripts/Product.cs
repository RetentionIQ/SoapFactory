using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product : MonoBehaviour
{
    public enum State
    {
        Ingredient,
        RawSoap,
        Produced
    }
    public State state;
    public bool passedEmployee = false;
    public bool passedMachine = false;


    public GameObject[] currentStateSkins;

    private ProductMovement productMovement;

    [SerializeField] private Rigidbody producedProduct;

    [SerializeField] private Product currentProductPrefab;

    public Sprite productIcon;

    [Header("Perfection Section :")]
    private float productPerfection = 1f;
    [SerializeField] private float maxPercentage = 1;
    [SerializeField] private float minPercentage = .7f;




    private void Awake()
    {
        productMovement = GetComponent<ProductMovement>();
    }

    void Start()
    {
        state = State.Ingredient;
    }

    public virtual void SetState(State state)
    {
        currentStateSkins[(int)this.state].SetActive(false);
        this.state = state;
    }

    public virtual void UpdateStateSkins()
    {
        switch (state)
        {
            case State.Produced:
                currentStateSkins[(int)State.Produced].SetActive(true);
                break;
            case State.RawSoap:
                currentStateSkins[(int)State.RawSoap].SetActive(true);
                break;
        }
    }
    public virtual ProductMovement GetMovement()
    {
        return productMovement;
    }
    public virtual void RestartData(Vector3 startPosition)
    {
        productMovement.SetNextPosIndex(0);
        passedEmployee = false;
        passedMachine = false;
        state = State.Ingredient;
        currentStateSkins[(int)State.Produced].SetActive(false);
        currentStateSkins[(int)State.Ingredient].SetActive(true);
        transform.position = startPosition;
    }


    public Rigidbody GetProducedProduct()
    {
        return producedProduct;
    }

    public abstract string GetProductName();
    public abstract int GetProductPrice();
    public abstract int GetSellPrice();

    public void SetRandomPerfectionValue(float addedValue)
    {
        float min = minPercentage + addedValue;
        float max = maxPercentage + addedValue;

        productPerfection = Random.Range(min, max);
        productPerfection = Mathf.Clamp(productPerfection , minPercentage, maxPercentage);
    }

    public float GetPerfectionValue()
    {
        return productPerfection;
    }

    public Product GetCurrentProductPrefab()
    {
        return currentProductPrefab;
    }

}
