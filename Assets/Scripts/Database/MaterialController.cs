using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    private MaterialData _data;

    private int _health;
    private int _defense;
    private MaterialType _materialName;
    private Material m_material;
    private bool _locked;
    List<MaterialData> _unlockedMaterials = new List<MaterialData>();

    public int Health { get => _health; private set => _health = value; }
    public int Defense { get => _defense; private set => _defense = value; }
    public MaterialType Name { get => _materialName; private set => _materialName = value; }
    public Material Material { get => m_material; private set => m_material = value; }
    public bool Locked { get => _locked; set => _locked = value; }

    //private SpriteRenderer _spriteRenderer;

    private void Awake() {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        UpdateListMaterial();
        InitNewMaterial(new MaterialType());
        _gameManager.OnEnd += InitNewMaterial;
        Debug.Log(_unlockedMaterials[0].Name);
        Debug.Log(_unlockedMaterials[1].Name);
        Debug.Log(_unlockedMaterials[2].Name);
    }


    public void InitNewMaterial(MaterialType materialType){
        UpdateListMaterial();
        int rng = Random.Range(0, _unlockedMaterials.Count);
        _data = _unlockedMaterials[rng];
        Health = _data.Health;
        Defense = _data.Defense;
        Name = _data.Name;
        Material = _data.Material;
        Locked = _data.Locked;
    }
    private void UpdateListMaterial()
    {
        _unlockedMaterials.Clear();
        foreach(MaterialData material in DatabaseManager.Instance.MaterialDatabase.Data)
        {
            if (!material.Locked)
            {
                _unlockedMaterials.Add(material);
            }
        }
    }
}
