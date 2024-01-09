using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _heat;
    [SerializeField] private Slider _progress;
    [SerializeField] private float _time;
    [SerializeField] private int _maxProg;
    [SerializeField] private int _dmg;
    [SerializeField] MaterialController _mc;
    private int _prog = 0;
    private float _timer = 0;

    private void Update() {
        _timer += Time.deltaTime;
        if(_timer >= _time){
            Debug.Log("You lose !");
            ReInit();
        }
        else{
            _heat.value = 1f-(_timer/_time);
        }
    }
    
    public void Progress(){
        _prog += _dmg;  
        if(_prog >= _maxProg){
            Debug.Log("Destroyed " + _mc.Name);
            ReInit();
        }
        _progress.value = (float)_prog/(float)_maxProg;
    }

    private void ReInit(){
        _mc.Init();
        _prog = 0;
        _progress.value = 0f;
        _timer = 0;
    }

}
