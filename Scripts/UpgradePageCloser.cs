using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePageCloser : MonoBehaviour
{
    [SerializeField] private GameObject[] upgradePages;
    // Start is called before the first frame update
    void Start()
    {
        Machines.OnAnyPageChange += Machines_OnAnyPageChange;
    }

    private void Machines_OnAnyPageChange(object sender, System.EventArgs e)
    {
        for (int i = 0; i < upgradePages.Length; i++)
        {
            upgradePages[i].SetActive(false);
        }
    }
    
}
