using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Machines iteractable;
    [SerializeField] private UpgradeButton upgradeButtonPrefab;
    [SerializeField] private Transform buttonsParent;

    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject upgradePage;

    private void Start()
    {

        foreach (Upgrade upgrade in GetComponents<Upgrade>())
        {
            UpgradeButton upgradeButton = Instantiate(upgradeButtonPrefab, upgradePage.transform);
            upgrade.machine = iteractable;
            upgradeButton.Setup(upgrade);

        }
    }


}
