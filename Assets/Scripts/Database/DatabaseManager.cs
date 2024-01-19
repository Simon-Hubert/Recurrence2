using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager _instance;
    [SerializeField] private MaterialDatabase _materialDatabase;
    [SerializeField] private ObjectDatabase _objectDatabase;

    public static DatabaseManager Instance { get => _instance; }
    public MaterialDatabase MaterialDatabase { get => _materialDatabase; }
    public ObjectDatabase ObjectDatabase { get => _objectDatabase; }

    
    private void Awake() {
        _instance ??= this;
    }
}
