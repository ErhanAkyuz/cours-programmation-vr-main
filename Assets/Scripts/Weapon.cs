using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;
    
    private Rigidbody _rigidbody;
    private XRGrabInteractable _interactableWeapon;
    
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _interactableWeapon = GetComponent<XRGrabInteractable>();
        SetupInteractableWeaponEvents();
    }
    
    private void SetupInteractableWeaponEvents()
    {
        _interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        _interactableWeapon.selectExited.AddListener(DropWeapon);
        _interactableWeapon.onActivate.AddListener(StartShooting);
        _interactableWeapon.onDeactivate.AddListener(StopShooting);
    }
    
    private void PickUpWeapon(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            interactor.gameObject.GetComponent<MeshHidder>().Hide();
        }
    }

    private void DropWeapon(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            interactor.gameObject.GetComponent<MeshHidder>().Show();
        }
    }

    
    protected virtual void StartShooting(XRBaseInteractor interactor)
    {
        // TODO
    }
    
    protected virtual void StopShooting(XRBaseInteractor interactor)
    {
        // TODO
    }
    
    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        _rigidbody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }
    
    public float getShootingForce()
    {
        return shootingForce;
    }
    
    public float GetDamage()
    {
        return damage;
    }
}
