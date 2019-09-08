using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseObject
{
    [SerializeField] protected Transform _gunT;
    [SerializeField] protected float _force = 300;
    [SerializeField] protected GameObject _crossHair;

    [SerializeField] protected ParticleSystem _muzzleFlash;
    //[SerializeField] protected Light _muzzleLigth;
    [SerializeField] protected GameObject _hitParticle;

    protected Timer _reachargeTimer = new Timer();

    protected bool _fire = true;

    public abstract void Fire();


     protected override void Awake()
    {
        base.Awake();
        _gunT = _GoTransform.GetChild(2);
        _crossHair = GameObject.FindGameObjectWithTag("cross");
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        _hitParticle = Resources.Load<GameObject>("Prefab/Flare");

    }

    
    protected virtual void Update()
    {
        _reachargeTimer.Update();

        if (_reachargeTimer.IsEvent())
        {
            _fire = true;

        }
    }
}
