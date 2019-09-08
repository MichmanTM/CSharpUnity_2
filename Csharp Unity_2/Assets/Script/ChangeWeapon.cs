﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : BaseObject
{
    private int weaponID = 0;

    void Start()
    {
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in _GoTransform)
        {
            if (i == weaponID)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    
    void Update()
    {
        int previousSlelectWeapon = weaponID;

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (weaponID <= 0)
            {
                weaponID = ChildCount - 1;
            }
            else
            {
                weaponID--;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (weaponID >= ChildCount -1 )
            {
                weaponID =0;
            }
            else
            {
                weaponID++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && ChildCount > 1)
        {
            weaponID = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&ChildCount>2)
        {
            weaponID = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ChildCount > 3)
        {
            weaponID = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && ChildCount > 4)
        {
            Debug.Log("Error"); //не нажимаеться 4 кнопка и последующие
            weaponID = 4;
        }

        if (previousSlelectWeapon != weaponID)
        {
            SelectWeapon();
        }
    }
}
