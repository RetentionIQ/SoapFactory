using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgrendientSelectorUI : MonoBehaviour
{
    [SerializeField] private SoapButton soapButtonUiPrefab;
    [SerializeField] private Transform parentTransform;

    [Header("UI ELEMENTS :")]
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject upgradePage;



    void Start()
    {
       // exitButton.onClick.AddListener(ExitPage);

        foreach(Product product in GetComponents<Product>())
        {
            SoapButton soapButton = Instantiate(soapButtonUiPrefab, parentTransform);
            soapButton.SetProduct(product);
        }
    }


    private void ExitPage()
    {
        upgradePage.SetActive(false);
    }

}
