using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ObjectType
{
    Sword,
    Shield,
    Spear,
    Arrow,
    Claymore,
    NumberOfTypes
}
[Serializable]
public class ObjectData
{
    [SerializeField] int _price;
    [SerializeField] ObjectType _name;
    [SerializeField] Sprite o_sprite;
    [SerializeField] MaterialType _material;
    [SerializeField] bool locked;

    public int Price { get => _price; set => _price = value; }
    public ObjectType Name_O { get => _name; set => _name = value; }
    public Sprite O_sprite { get => o_sprite; set => o_sprite = value; }
    public MaterialType Material { get => _material; set => _material = value; }
    public bool Locked_O { get => locked; set => locked = value; }
}
