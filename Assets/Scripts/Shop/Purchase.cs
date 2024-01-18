using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    [SerializeField]string _name;
    public int price;
    public SetUpStore _SetStore;
    public InventoryManager _iManager;
    [SerializeField] MaterialDatabase _mDatabase;
    [SerializeField] ObjectDatabase _oDatabase;


    public string Name { get => _name; set => _name = value; }
    public int Price { get => price; set => price = value; }
    public SetUpStore SetStore { get => _SetStore; set => _SetStore = value; }
    public InventoryManager IManager { get => _iManager; set => _iManager = value; }

    public void OnPurchase()
    {
        if (_iManager.MoneyCount >= price)
        {
            foreach (MaterialData mdata in _mDatabase.Data)
            {
                if (mdata.Label == _name)
                {
                    mdata.Locked = false;
                    _SetStore.SetStore();
                    Debug.Log(mdata.Label + mdata.Locked);
                    _iManager.MoneyCount -= price;
                    _iManager.PurchaseObject();
                }
            }
            foreach (ObjectData odata in _oDatabase.Data)
            {
                if (odata.Label == _name)
                {
                    odata.Locked = false;
                    _SetStore.SetStore();
                    Debug.Log(odata.Label + odata.Locked);
                    _iManager.MoneyCount -= price;
                    _iManager.PurchaseObject();
                }
            }
        }

    }
}
