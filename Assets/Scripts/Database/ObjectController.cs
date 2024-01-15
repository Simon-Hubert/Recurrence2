using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    ObjectData _data;
    int _price;
    string _name;
    Sprite o_sprite;
    MaterialType _material;
    List<ObjectData> _goodObjects = new List<ObjectData>();

    public int Price { get => _price; private set => _price = value; }
    public string Name { get => _name; private set => _name = value; }
    public Sprite O_sprite { get => o_sprite; private set => o_sprite = value; }
    public MaterialType Material { get => _material; set => _material = value; }
    private void Awake()
    {
        _gameManager.OnEnd += Init;
    }

    void Init(MaterialType _material)
    {
        Debug.Log("Init" + _material);
        SetList(_material);

        if (_goodObjects.Count > 0)
        {
            int rdm = Random.Range(0, _goodObjects.Count);
            _data = _goodObjects[rdm];
            Price = _data.Price;
            Name = _data.Name_O;
            O_sprite = _data.O_sprite;
            Material = _data.Material;

            InventoryManager.Instance.AddObject(_data);
            Debug.Log(_data.Name_O + " " + _data.Material.ToString());
        }
        else
        {
            Debug.LogError("No good objects found for the specified material.");
        }
        /*do
        {
            Debug.Log("Init");
            int rdm = Random.Range(0, DatabaseManager.Instance.ObjectDatabase.Data.Count);
            _data = DatabaseManager.Instance.ObjectDatabase.Data[rdm];
            Price = _data.Price;
            Name = _data.Name_O;
            O_sprite = _data.O_sprite;
            Material = _data.Material;
            
        }while(_data.Material != _material);*/



    }
    void SetList(MaterialType _material)
    {
        _goodObjects.Clear();
        foreach(ObjectData obj in DatabaseManager.Instance.ObjectDatabase.Data)
        {
            if (obj.Material == _material)
            {
                _goodObjects.Add(obj);
            }
        }
    }
}