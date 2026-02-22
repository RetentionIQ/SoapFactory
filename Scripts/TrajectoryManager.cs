using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryManager : MonoBehaviour
{
    [SerializeField] private Transform[] ingredientTrejectory;
    [SerializeField] private Transform[] soapTrejectory;
    [SerializeField] private Transform[] producedTrejectory;


    public static TrajectoryManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public Transform[] GetIngredientTrejectory()
    {
        return ingredientTrejectory;
    }
    public Transform[] GetSoapTrejectory()
    {
        return soapTrejectory;
    }
    public Transform[] GetProducedTrejectory()
    {
        return producedTrejectory;
    }
}
