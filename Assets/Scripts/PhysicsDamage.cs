using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 hitPoint)
    {
        _rigidbody.AddForceAtPosition(projectile.transform.forward * weapon.getShootingForce(), hitPoint, ForceMode.Impulse);
    }
    
}
