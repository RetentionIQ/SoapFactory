using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Machines : MonoBehaviour
{
    [SerializeField] private GameObject interactableMenu;
    [SerializeField] private GameObject machineTutorialVisuals;

    public bool isTutorial = false;

    public event EventHandler OnProductPassed;

    public float actionSpeed = 3f;
    public float cannonMissChance = .3f;

    public static event EventHandler OnAnyPageChange;


    public void Interact()
    {
        interactableMenu.SetActive(true);
    }


    public void OnMouseDown()
    {
        //Set all machines menu to false before opening a new one!
        OnAnyPageChange?.Invoke(this, EventArgs.Empty);
        Interact();
        if (isTutorial)
        {
            SetIsTutorial(false);
            //Show Text Explaining abilities!
        }
    }
    protected void OnProductPassedEventCaller()
    {
        OnProductPassed?.Invoke(this, EventArgs.Empty);
    }

    public abstract void BuySpeed();

    public abstract void BuyAccuracy();

    public abstract void BuyPerfection();


    public GameObject GetMachineTutorialVisual()
    {
        return machineTutorialVisuals;
    }

    public void SetIsTutorial(bool isTutorial)
    {
        this.isTutorial = isTutorial;
        machineTutorialVisuals.SetActive(isTutorial);
    }
}
