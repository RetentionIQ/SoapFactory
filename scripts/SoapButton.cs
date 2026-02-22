using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoapButton : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI pricetext;
    private Product product;
    private Button actionButton;

    public Image productIcon;
    [SerializeField] private GameObject priceHolder;

    private void Awake()
    {
        actionButton = GetComponent<Button>();
    }

    private void Start()
    {
        actionButton.onClick.AddListener(TakeAction);
      /*  if(product is BaseSoap || PlayerPrefs.GetInt(product.GetProductName() , 0) == 1)
        {
            priceHolder.SetActive(false);
        }/*/
    }

    private void UpdateUI()
    {
        pricetext.text = product.GetProductPrice().ToString();
        productIcon.sprite = product.productIcon;

        //TESTING
        if (product is BaseSoap || PlayerPrefs.GetInt(product.GetProductName(), 0) == 1)
        {
            priceHolder.SetActive(false);
        }
    }

    public void TakeAction()
    {
        if (CashManager.Instance.BuyAProduct(product))
        {
            UpdateUI();
            IngredientSelector.Instance.SetCurrentProduct(product.GetCurrentProductPrefab());
        }


        
    }

    public void SetProduct(Product product)
    {
        this.product = product;
        UpdateUI();
    }
}
