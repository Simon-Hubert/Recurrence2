using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database_O")]
public class ObjectDatabase : ScriptableObject
{
    [SerializeField] private List<ObjectData> _data = new();
    public List<ObjectData> Data { get => _data; }
    int basePrice = 5;

    [Button]
    private void GenerateObjectDatabase()
    {
        _data.Clear();
        for(int i = 0; i < (int)ObjectType.NumberOfTypes; i++)
        {
            for(int j = 0; j <(int)MaterialType.NumberOfTypes; j++)
            {
                ObjectData data = new ObjectData();
                data.Name_O = (ObjectType)i;
                data.Material = (MaterialType)j;
                if((int)data.Material >= (int)MaterialType.Gold || (int)data.Name_O >= (int)ObjectType.Arrow)
                {
                    data.Locked_O = true;
                }
                data.Price = basePrice * 2 *(int)ObjectType.NumberOfTypes;
                _data.Add(data);
                
            }
        }
    }
}
