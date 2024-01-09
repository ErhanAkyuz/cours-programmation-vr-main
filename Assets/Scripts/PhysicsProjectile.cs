using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float lifeTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public override void Init(Weapon weapon)
    {
        Debug.Log("Initializing physics projectile");
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        Debug.Log("Launching physics projectile");
        base.Launch();
        _rigidbody.AddRelativeForce(Vector3.left * weapon.getShootingForce(), ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") || other.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Physics projectile collided with " + other.name);
        Destroy(gameObject);
        ITakeDamage[] damageTakers = other.GetComponentsInChildren<ITakeDamage>();
        
        foreach (var damageTaker in damageTakers)
        {
            damageTaker.TakeDamage(weapon, this, transform.position);
        }
    }
}
