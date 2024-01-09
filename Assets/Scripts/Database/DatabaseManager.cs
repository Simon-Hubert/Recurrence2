using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager _instance;
    [SerializeField] private MaterialDatabase _materialDatabase;

    public static DatabaseManager Instance { get => _instance; }
    public MaterialDatabase MaterialDatabase { get => _materialDatabase; }

    
    private void Awake() {
        _instance ??= this;
    }
}
