using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUpStore : MonoBehaviour
{
    [SerializeField] IDatabase _database;
    [SerializeField] Transform _contentStore;
    [SerializeField] GameObject _storeUI;
    public void SetStore()
    {
        //clean store
        foreach(Transform _itemClone in _contentStore)
        {
            Destroy(_itemClone.gameObject);
        }

        foreach (IData data in _database.Data)
        {
            if(data.Locked)
            {
               GameObject _storeCUI = Instantiate(_storeUI, _contentStore);
                var _itemName = _storeUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                var _itemIcon = _storeUI.transform.Find("Icon").GetComponent<Image>();
                var _buyingButton = _storeUI.transform.Find("Purchase").GetComponent<Button>();
                var _price = _storeUI.transform.Find("Price").GetComponent<TextMeshProUGUI>();

                _itemName.text = data.Label;
                _itemIcon.sprite = data.O_sprite;
            }
        }
    }

}
