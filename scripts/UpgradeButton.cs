using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradePriceText;

    [SerializeField] private Button buyButton;

    [SerializeField] private Image iconImage;

    private Upgrade currentUpgrade;


    public void Setup(Upgrade upgrade)
    {
        currentUpgrade = upgrade;

        iconImage.sprite = upgrade.upgradeImage;

        upgradePriceText.text = upgrade.GetUpgradePrice().ToString();

        buyButton.onClick.AddListener(TakeAction);
    }

    private void TakeAction()
    {
        currentUpgrade.TakeAction();
        upgradePriceText.text = currentUpgrade.GetUpgradePrice().ToString();
    }

}
