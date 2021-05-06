
using System;
using DefaultNamespace;
using UnityEngine;

public class MoveableStickman : MonoBehaviour
{
    [SerializeField] protected float Speed;
    protected new Rigidbody rigidbody;
    
    [SerializeField]
    protected ParticleSystem _deathParticle;

    [SerializeField]
    protected SkinnedMeshRenderer skin;
    
    [SerializeField]
    protected WeaponHolder weaponHolder;

    [SerializeField] private WeaponsTagsList weaponsTagsList;

    [HideInInspector] public bool liveState =  true;

    protected Animator Animator;
    

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        if (liveState)
        {
            Move();
        }
    }

    protected virtual void Move(){}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (weaponsTagsList.weaponsTags.Contains(other.tag))
        {
            other.gameObject.SetActive(false);
            weaponHolder.AddWeapon(other.tag);
        }
    }

    protected void Death()
    {
        _deathParticle.Play();
        skin.enabled = false;
        liveState = false;
        weaponHolder.DropWeapon();
        
        if (this.gameObject.CompareTag("Enemy"))
        {
             Destroy(this.gameObject, 2f);
        }
       
    }
}
