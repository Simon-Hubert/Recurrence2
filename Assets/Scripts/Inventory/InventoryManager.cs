using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] List<ObjectData> objectInInventory = new List<ObjectData>();
    [SerializeField] GameObject _inventoryUI;
    [SerializeField] Transform _inventoryContent;
    [SerializeField] Toggle EnableSelling;
    [SerializeField] InventoryItemController[] _inventoryItems;
    [SerializeField] TextMeshProUGUI _money;
    [SerializeField] MVO _mvo;
    
    [SerializeField] int _moneyCount = 0;

    public int MoneyCount { get => _moneyCount; set => _moneyCount = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            _money.text = MoneyCount.ToString();
        }
        else
        {
            Debug.LogError("Multiple InventoryManager in the scene");
        }
    }

    public void AddObject(ObjectData _object)
    {
        objectInInventory.Add(_object);
        Debug.Log("Added " + _object.Name_O + " to inventory");
    }

    public void SellObject(ObjectData _object)
    {
        int bonus = 1;
        if(_object.Name_O.ToString() == _mvo.MvoName)
        {
            int sup = Random.Range(0, 4);
            if(sup > 2 )
            {
                bonus = 3;
            }
            else
            {
                bonus = 2;
            }
        }
        MoneyCount += _object.Price * bonus;
        Debug.Log(_object.Label + " " + _object.Price + " " + _object.Price * bonus);
        objectInInventory.Remove(_object);
        _money.text = MoneyCount.ToString();
    }
    public void PurchaseObject()
    {
        _money.text = MoneyCount.ToString();
    }

    public void ListItems()
    {
        //Clean the inventory
        foreach(Transform _objectClone in _inventoryContent)
        {
            Destroy(_objectClone.gameObject);
        }

        foreach(ObjectData _object in objectInInventory)
        {
           GameObject _objectUI = Instantiate(_inventoryUI, _inventoryContent);
            var _itemName = _objectUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var _itemIcon = _objectUI.transform.Find("ItemIcon").GetComponent<Image>();
            var _sellingButton = _objectUI.transform.Find("Selling").GetComponent<Button>();

            _itemName.text = _object.Name_O.ToString();
            _itemIcon.sprite = _object.O_sprite;

            if(EnableSelling.isOn)
            {
                _sellingButton.gameObject.SetActive(true);
            }
            else
            {
                _sellingButton.gameObject.SetActive(false);
            }
        }
        SetInventoryItems();
    }

    public void ToggleSelling()
    {
        if(EnableSelling.isOn)
        {
            foreach(Transform _objectClone in _inventoryContent)
            {
                _objectClone.Find("Selling").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform _objectClone in _inventoryContent)
            {
                _objectClone.Find("Selling").gameObject.SetActive(false);
            }
        }
    }
    
    public void SetInventoryItems()
    {
        _inventoryItems = _inventoryContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < objectInInventory.Count; i++)
        {
            _inventoryItems[i].AddItem(objectInInventory[i]);
        }
    }
}
