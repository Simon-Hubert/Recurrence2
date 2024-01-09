using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectData
{
    public enum MaterialType
    {
        Steel,
        Copper,
        Iron,
    }
    [SerializeField] int _price;
    [SerializeField] string _name;
    [SerializeField] SpriteRenderer o_sprite;
    [SerializeField] MaterialType _material;

    public int Price { get => _price; set => _price = value; }
    public string Name_O { get => _name; set => _name = value; }
    public MaterialType Material { get => _material; set => _material = value; }
    public SpriteRenderer O_sprite { get => o_sprite; set => o_sprite = value; }
}
