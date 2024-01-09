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

    public int Health { get => _health; private set => _health = value; }
    public int Defense { get => _defense; private set => _defense = value; }
    public MaterialType Name { get => _materialName; private set => _materialName = value; }
    public Material Material { get => m_material; private set => m_material = value; }

    //private SpriteRenderer _spriteRenderer;

    private void Awake() {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        Init();
    }


    public void Init(){
        int rng = Random.Range(0, DatabaseManager.Instance.MaterialDatabase.Data.Count);
        _data = DatabaseManager.Instance.MaterialDatabase.Data[rng];
        Health = _data.Health;
        Defense = _data.Defense;
        Name = _data.Name;
        Material = _data.Material;
    }
}
