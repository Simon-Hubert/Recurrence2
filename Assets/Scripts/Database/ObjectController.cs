using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    ObjectData _data;
    int _price;
    string _name;
    SpriteRenderer o_sprite;
    string _material;

    public int Price { get => _price; private set => _price = value; }
    public string Name { get => _name; private set => _name = value; }
    public SpriteRenderer O_sprite { get => o_sprite; private set => o_sprite = value; }
    public string Material { get => _material; set => _material = value; }
    private void Awake()
    {
        _gameManager.OnEnd += Init;
    }

    void Init(string _material)
    {
        do
        {
            Debug.Log("Init");
            int rdm = Random.Range(0, DatabaseManager.Instance.ObjectDatabase.Data.Count);
            _data = DatabaseManager.Instance.ObjectDatabase.Data[rdm];
            Price = _data.Price;
            Name = _data.Name_O;
            O_sprite = _data.O_sprite;
            Material = _data.Material.ToString();
        }while(_data.Material.ToString() != _material);

        Debug.Log(_data.Name_O + " " + _data.Material.ToString());
    }
}