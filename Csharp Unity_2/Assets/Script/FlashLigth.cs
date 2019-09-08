using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigth : BaseObject
{
    private KeyCode control = KeyCode.F;

   // private float Timeout = 10;
    private Light _ligth;
    //private float currTime;
    private float currReloadTime;
    private float _energy = 100;
    private float _scet;

    private Material _ligthMat;

    void Start()
    {
        _ligth = GetComponentInChildren<Light>();
        _ligthMat = GetMaterial;
    }

    private void ActiveFlashligth(bool val)
    {
        _ligth.enabled = val;
    }
    
    void Update()
    {
        if (_ligth.enabled)
        {
            _scet += 1 * Time.deltaTime;
            if (_scet >= 2)
            {
                _energy -= 1;
                _scet = 0;
            }
        }
        if (!_ligth.enabled)
        {
            _scet += 1 * Time.deltaTime;
            if (_scet >= 2)
            {
                _energy += 1;
                _scet = 0;
            }
        }
        if (_energy >= 100)
        {
            _energy = 100;
        }
        if (_energy <= 0)
        {
            _energy = 0;
        }
        if (Input.GetKeyDown(control)&& !_ligth.enabled && _energy >0)
        {
            ActiveFlashligth(true);
            
        }
        else if (Input.GetKeyDown(control) && _ligth.enabled)
        {
            ActiveFlashligth(false);
        }
        //if (_ligth.enabled)
        //{
        //    currTime += Time.deltaTime;
            
        //    if(currTime> Timeout)
        //    {
        //        currTime = 0;
        //        ActiveFlashligth(false);
        //    }
        //}
       
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Energy " + _energy +" %");
    }
}
