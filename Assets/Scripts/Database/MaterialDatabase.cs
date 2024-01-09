using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Database")]
public class MaterialDatabase : ScriptableObject {
    [SerializeField] private List<MaterialData> _data = new();

    public List<MaterialData> Data { get => _data;}
}

