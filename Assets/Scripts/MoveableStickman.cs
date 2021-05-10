
using System;
using DefaultNamespace;
using UnityEngine;

public class MoveableStickman : MonoBehaviour
{
    [SerializeField] protected float Speed;
    
    protected Rigidbody rigidbody;
    
    [SerializeField]
    protected ParticleSystem _deathParticle;

    [SerializeField]
    protected SkinnedMeshRenderer skin;
    
    [SerializeField]
    public WeaponHolder weaponHolder;

    [SerializeField] private WeaponsTagsList weaponsTagsList;

    [HideInInspector] public bool liveState =  true;

    protected Animator Animator;

    [HideInInspector] public bool isWeapon =  false;

    [SerializeField] private GameObject looseUI;

    [HideInInspector] public bool isFinishDeath = false;
    

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
            isWeapon = true;
        }
    }

    public void Death()
    {
        _deathParticle.Play();
        skin.enabled = false;
        liveState = false;
        weaponHolder.DropWeapon();
        
        if (this.gameObject.CompareTag("Enemy"))
        {
             BattleController._enemysCount.RemoveAt(0);
             Destroy(this.gameObject, 2f);
        }
        
        if (this.gameObject.CompareTag("Player") && !isFinishDeath)
        {
            looseUI.SetActive(true);
        }
       
    }

    public float GetSpeed()
    {
        return Speed;
    }

    public void SetSpeed(float f)
    {
        Speed = f;
    }
}
