using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialType
{
    Steel,
    Copper,
    Iron,
    Gold,
    Diamond,
    Obsidian,
    NumberOfTypes
}
[Serializable]
public class MaterialData: IData
{
    
    [SerializeField] int _health;
    [SerializeField] int _defense;
    [SerializeField] Material m_material;
    [SerializeField] MaterialType _name;
    [SerializeField] bool locked;
    [SerializeField] string _label;
    [SerializeField] Sprite _sprite;

    public int Health { get => _health; set => _health = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public Material Material { get => m_material; set => m_material = value; }
    public MaterialType Name { get => _name; set => _name = value; }
    public bool Locked { get => locked; set => locked = value; }
    public string Label { get => _label; set => _label = value; }
    public Sprite O_sprite { get => _sprite; set => _sprite = value; }

}
