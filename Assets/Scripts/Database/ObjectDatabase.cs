using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database_O")]
public class ObjectDatabase : ScriptableObject
{
    [SerializeField] private List<ObjectData> _data = new();
    public List<ObjectData> Data { get => _data; }
}
