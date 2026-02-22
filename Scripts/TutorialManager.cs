using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private Machines[] machines;

    public static TutorialManager Instance;

    private int totalCash = 0;

    private int index = 0;


    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        machines[index].SetIsTutorial(true);
        CashManager.Instance.OnCashUpdated += Instance_OnCashUpdated;
        totalCash = CashManager.Instance.GetCash();
    }

    private void Instance_OnCashUpdated(object sender, int e)
    {


        if(e > 150)
        {
            totalCash -= 300;
            AddNext();
        }
    }

    public void AddNext()
    {
        index++;

        if (index >= machines.Length) return;

        machines[index].SetIsTutorial(true);
    }
}
