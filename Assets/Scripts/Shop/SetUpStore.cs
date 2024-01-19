using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUpStore : MonoBehaviour
{
    [SerializeField] MaterialDatabase _mDatabase;
    [SerializeField] ObjectDatabase _oDatabase;
    [SerializeField] Transform _contentStore;
    [SerializeField] GameObject _storeUI;
    public void SetStore()
    {
        //clean store
        foreach(Transform _itemClone in _contentStore)
        {
            Destroy(_itemClone.gameObject);
        }

        if(_oDatabase != null)
        {
            foreach (ObjectData data in _oDatabase.Data)
            {
                if (data.Locked)
                {
                     GameObject _storeCUI = Instantiate(_storeUI, _contentStore);
                     var _itemName = _storeCUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                     var _itemIcon = _storeCUI.transform.Find("Icon").GetComponent<Image>();
                     var _buyingButton = _storeCUI.transform.Find("Purchase").GetComponent<Button>();
                     var _price = _storeUI.transform.Find("Price").GetComponent<TextMeshProUGUI>();
                     var _purchase = _buyingButton.GetComponent<Purchase>();

                    _itemName.text = data.Label;
                     _itemIcon.sprite = data.O_sprite;
                    _price.text = (data.Price * 10).ToString();
                    _purchase.Name = _itemName.text;
                    _purchase.Price = int.Parse(_price.text);
                    _purchase.SetStore = this;
                    _purchase.IManager = GameObject.FindObjectOfType<InventoryManager>();
                }
            }
        }
        else if(_mDatabase != null)
        {
            foreach (MaterialData data in _mDatabase.Data)
            {
                if (data.Locked)
                {
                    GameObject _storeCUI = Instantiate(_storeUI, _contentStore);
                    var _itemName = _storeUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                    var _itemIcon = _storeUI.transform.Find("Icon").GetComponent<Image>();
                    var _buyingButton = _storeUI.transform.Find("Purchase").GetComponent<Button>();
                    var _price = _storeUI.transform.Find("Price").GetComponent<TextMeshProUGUI>();
                    var _purchase = _buyingButton.GetComponent<Purchase>();

                    _itemName.text = data.Label;
                    _itemIcon.sprite = data.O_sprite;
                    _price.text = (data.Price).ToString();
                    _purchase.Name = _itemName.text;
                    _purchase.Price = int.Parse(_price.text);
                    _purchase.SetStore = this;
                    _purchase.IManager = GameObject.FindObjectOfType<InventoryManager>();
                }
            }
        }

    }

}
