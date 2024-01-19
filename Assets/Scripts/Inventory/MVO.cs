using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MVO : MonoBehaviour
{
    float journey;
    string mvoName, timeString;
    [SerializeField] ObjectDatabase _base;
    [SerializeField] TextMeshProUGUI _mVOName, _time;

    List<ObjectData> _data = new List<ObjectData>();

    public string MvoName { get => mvoName; set => mvoName = value; }

    private void Start()
    {
        MVOCalculation();
    }
    void Update()
    {
        journey += Time.deltaTime/5;
        if(journey > 24 )
        {
            MVOCalculation();
            journey = 0;
        }
        //timeString = ((int)Mathf.Floor(journey)).ToString() + " H " + ((int)Mathf.Ceil(journey)).ToString();
        timeString = ((int)journey).ToString();
        _time.text = timeString;
    }

    void MVOCalculation()
    {
        foreach(ObjectData obj in _base.Data)
        {
            if(!obj.Locked)
            {
                _data.Add(obj);
            }
        }
        int rand = Random.Range(1, _data.Count);
        //Debug.Log(rand);
        MvoName = _data[rand].Name_O.ToString();
        _mVOName.text = MvoName;
        //Debug.Log(mvoName);
    }
}
