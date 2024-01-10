using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float lifeTime;
    private Rigidbody _rigidbody;
    private GameManager gameManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    
    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        _rigidbody.AddRelativeForce(Vector3.left * weapon.getShootingForce(), ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Weapon") || other.gameObject.CompareTag("Player"))
        {
            return;
        } else if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("Physics projectile collided with ennemy " + other.gameObject.name);
            Destroy(gameObject);
            // Ajouter le score
            if (gameManager != null)
            {
                
                int currentScore = gameManager.GetScore();
                Debug.Log("Score actuel : "+ currentScore+", Ajout 10 points");
                gameManager.SetScore(currentScore + 10); // Ajoute 10 points
            }

            Destroy(other.gameObject);
            /*
            ITakeDamage[] damageTakers = other.gameObject.GetComponentsInChildren<ITakeDamage>();

            foreach (var damageTaker in damageTakers)
            {
                damageTaker.TakeDamage(weapon, this, transform.position);
            }
            */
        }
    }
}
