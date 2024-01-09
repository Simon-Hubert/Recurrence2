using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class MaterialData
{
    [SerializeField] int _health;
    [SerializeField] int _defense;
    [SerializeField] string _name;
    [SerializeField] Material m_material;

    public int Health { get => _health; set => _health = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public string Name { get => _name; set => _name = value; }
    public Material Material { get => m_material; set => m_material = value; }
}
