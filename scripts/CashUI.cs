using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        CashManager.Instance.OnCashUpdated += CashManager_OnCashAdded;
        UpdateUI(CashManager.Instance.GetCash());
    }

    private void CashManager_OnCashAdded(object sender, int e)
    {
        UpdateUI(e);
    }

    private void UpdateUI(int value)
    {
        moneyText.text = value.ToString();
    }
}
