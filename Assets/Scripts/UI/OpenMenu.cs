using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] Animator _menuAnm;
    bool _isOpen = false;

    public void AnmMenu()
    {
        _isOpen = !_isOpen;
        _menuAnm.GetComponent<Animator>().SetBool("Open", _isOpen);
    }
}
