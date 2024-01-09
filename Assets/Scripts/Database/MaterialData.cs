using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialType
{
    Steel,
    Copper,
    Iron,
}
[Serializable]
public class MaterialData
{
    
    [SerializeField] int _health;
    [SerializeField] int _defense;
    [SerializeField] Material m_material;
    [SerializeField] MaterialType _name;

    public int Health { get => _health; set => _health = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public Material Material { get => m_material; set => m_material = value; }
    public MaterialType Name { get => _name; set => _name = value; }
}
