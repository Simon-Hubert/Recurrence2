using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


[CreateAssetMenu(menuName = "Database_M")]
public class MaterialDatabase : ScriptableObject {
    [SerializeField] private List<MaterialData> _data = new();

    public List<MaterialData> Data { get => _data;}
    int basePrice = 100;
    int baseHealth = 50;
    int baseDef = 10;
    [Button]
    void GenerateMaterials()
    {
        _data.Clear();
        for (int i = 0; i < (int)MaterialType.NumberOfTypes; i++)
        {
                MaterialData data = new MaterialData();
                data.Name = (MaterialType)i;
                if ((int)data.Name >= (int)MaterialType.Gold)
                {
                    data.Locked = true;
                }
                data.Health = baseHealth * (i + 3 / 2);
                data.Defense = baseDef * (i + 3/2);
                data.Label = data.Name.ToString();
                data.Price = basePrice* 2 * (int)ObjectType.NumberOfTypes * (i + 1);
                _data.Add(data);
        }
    }

    private void OnValidate()
    {
        foreach(MaterialData data in _data)
        {
            data.Label = data.Name.ToString();
        }
    }
}

