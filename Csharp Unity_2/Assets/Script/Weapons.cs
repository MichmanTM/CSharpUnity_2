using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : BaseWeapon
{
    private int _bulletCount = 30;
    private float _shootDistance = 1000f;
    private int _damage = 20;
    private int _curDamage;
    private float _destructTime = 10f;

    private void SetDamage(IsetDamage obj)
    {
        _curDamage = _damage;
        if (obj != null)
        {
            obj.SetDamage(_curDamage);
        }
    }

    public override void Fire()
    {
        if (_bulletCount > 0 && _fire)
        {
            _muzzleFlash.Play();

            _bulletCount--;

             RaycastHit hit;
             Ray ray = new Ray(MainCam.transform.position, MainCam.transform.forward);
             if (Physics.Raycast(ray, out hit, _shootDistance))
             {
                    if (hit.collider.tag == "Player")
                    {
                        return;

                    }
                else
                {
                    SetDamage(hit.collider.GetComponent<IsetDamage>());
                }
                GameObject tempHit = Instantiate(_hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
                tempHit.transform.parent = hit.transform;
                Destroy(tempHit, 0.5f);
             }

        }
    }
    Vector3 GetDirection(Vector3 HitPoint, Vector3 BulletPos)
    {
        Vector3 decr = HitPoint - BulletPos;
        float dist = decr.magnitude;
        return decr / dist;
    }

    protected override void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _bulletCount = 30;
        }
    }
}
