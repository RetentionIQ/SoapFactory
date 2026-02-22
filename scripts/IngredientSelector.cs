using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSelector : Machines
{
    [SerializeField] private Product ingredient;

    public List<Product> productObjectPooling;

    private Dictionary<string, Queue<Product>> productDictionary = new Dictionary<string, Queue<Product>>(); // We're gonna use this later on to optimize the game!

    private float timeBtwSpawn;

    public static IngredientSelector Instance;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        timeBtwSpawn = actionSpeed;
    }


    private void Update()
    {



        if(timeBtwSpawn <= 0)
        {
            timeBtwSpawn = actionSpeed;

            

            //if (!CashManager.Instance.BuyAProduct(ingredient)) return;
            print("Passed!");


            bool foundMatch = false;

            for (int i = 0; i < productObjectPooling.Count; i++)
            {
                if(productObjectPooling[i].GetProductName() == ingredient.GetProductName())
                {

                    productObjectPooling[i].gameObject.SetActive(true);
                    productObjectPooling[i].RestartData(TrajectoryManager.Instance.GetIngredientTrejectory()[0].position);
                    productObjectPooling.RemoveAt(i);
                    foundMatch = true;
                    break;
                }
            }

            if (!foundMatch)
            {
                Product product = Instantiate(ingredient, TrajectoryManager.Instance.GetIngredientTrejectory()[0].position, Quaternion.identity);
                product.GetMovement().SetTrajectory(TrajectoryManager.Instance.GetIngredientTrejectory());
            }

          /*  if(productObjectPooling.Count > 0)
            {
                productObjectPooling[0].gameObject.SetActive(true);
                productObjectPooling[0].RestartData(TrajectoryManager.Instance.GetIngredientTrejectory()[0].position);
                productObjectPooling.RemoveAt(0);
            }
            else
            {
                Product product = Instantiate(ingredient, TrajectoryManager.Instance.GetIngredientTrejectory()[0].position, Quaternion.identity);
                product.GetMovement().SetTrajectory(TrajectoryManager.Instance.GetIngredientTrejectory());
            }/*/

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    public List<Product> GetProductObjectPooling()
    {
        return productObjectPooling;
    }

    public void SetCurrentProduct(Product ingredient)
    {
        this.ingredient = ingredient;
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
