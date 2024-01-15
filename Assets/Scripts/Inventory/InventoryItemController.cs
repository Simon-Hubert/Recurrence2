using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    ObjectData _object;
    [SerializeField] Button SellingButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.RemoveObject(_object);
        Destroy(gameObject);
    }
    
    public void AddItem(ObjectData _newObject)
    {
        _object = _newObject;
    }

}
