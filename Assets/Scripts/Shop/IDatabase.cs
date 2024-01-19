using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDatabase
{
    List<IData> Data{ get;}
    
}
public interface IData
{
    bool Locked { get; set; }
    string Label { get; set; }
    Sprite O_sprite { get; set; }
}