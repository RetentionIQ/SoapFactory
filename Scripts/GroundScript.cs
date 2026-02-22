using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ProducedProduct producedProduct))
        {
            Cannon.Instance.AddProductToPool(producedProduct);
        }
    }
}
