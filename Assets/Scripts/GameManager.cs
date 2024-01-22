using System;
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
    public event Action<MaterialType> OnEnd;
    public event Action<MaterialType> OnEndWin;

    private void Update() {
        _timer += Time.deltaTime;
        if(_timer >= _time){
            Debug.Log("You lose !");
            ReInitLose();
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
        OnEnd?.Invoke(_mc.Name);
        OnEndWin?.Invoke(_mc.Name);
        _prog = 0;
        _progress.value = 0f;
        _timer = 0;
    }
    private void ReInitLose()
    {
        OnEnd?.Invoke(_mc.Name);
        _prog = 0;
        _progress.value = 0f;
        _timer = 0;
    }
    public void Quit()
    {
        Application.Quit();
    }

}
