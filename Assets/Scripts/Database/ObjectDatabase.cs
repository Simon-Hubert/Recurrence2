using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Database_O")]
public class ObjectDatabase : ScriptableObject
{
    [SerializeField] private Sprite[] _spritesInOrder;
    [SerializeField] private Color[] _colorsInOrder;
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
                    data.Locked = true;
                }
                data.Label = data.Name_O.ToString()+"_"+data.Material.ToString();
                data.Price = basePrice * (j+1) *(int)ObjectType.NumberOfTypes * (i+1);

                Sprite sprite = GenerateSprite(_colorsInOrder[j%_colorsInOrder.Count()],
                                               _spritesInOrder[i%_spritesInOrder.Count()],
                                               data.Label);
                data.O_sprite = sprite;

                _data.Add(data);
            }
        }
    }

    private Sprite GenerateSprite(Color col, Sprite grayscaleSprite, string name){
        Texture2D originalTex = grayscaleSprite.texture;
        Texture2D newTex = new Texture2D(originalTex.width, originalTex.width);

        for (int x = 0; x < originalTex.width; x++)
        {
            for (int y = 0; y < originalTex.height; y++)
            {
                Color brightness = originalTex.GetPixel(x,y);
                Color newColor = col * brightness.r * brightness.a;
                //Debug.Log(newColor);
                newTex.SetPixel(x,y,newColor);
            }
        }

        newTex.Apply();

        Sprite sp = Sprite.Create(newTex, new Rect(0,0,newTex.width, newTex.height), Vector2.zero);
        sp.name = name; 
        return SaveSprite(sp, name);
    }

    Sprite SaveSprite(Sprite sp, string name){
        string assetPath = "Assets/Sprites/Generated"+name+".png";

        string directoryPath = Path.GetDirectoryName(Application.dataPath + "/../" + assetPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllBytes(Application.dataPath + "/../" + assetPath, sp.texture.EncodeToPNG());
        AssetDatabase.Refresh();
        var ti =AssetImporter.GetAtPath(assetPath) as TextureImporter;
        ti.textureType = TextureImporterType.Sprite;
        ti.filterMode = FilterMode.Point;
        EditorUtility.SetDirty(ti);
        ti.SaveAndReimport();

        //AssetDatabase.AddObjectToAsset(sp, assetPath);
        
        //AssetDatabase.CreateAsset(sp, assetPath);
        //AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        return AssetDatabase.LoadAssetAtPath(assetPath, typeof(Sprite)) as Sprite;
    }
}