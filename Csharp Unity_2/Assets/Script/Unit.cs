using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : BaseObject, IsetDamage
{
   [SerializeField] private int _helth;

    public int Helth { get => _helth; set => _helth = value; }

   public void SetDamage(int damage)
    {
        if (_helth > 0)
        {
            _helth -= damage;

        }
        if (Helth <= 0)
        {
            _helth = 0;
            Destroy(_GOInstance);
        }
    }

   
    
}
