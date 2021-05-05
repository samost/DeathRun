
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponHolder : MonoBehaviour
{
    private GameObject currentWeapon;
    private void Start()
    {
        currentWeapon = null;
    }

    public void AddWeapon(string tag)
    {
        foreach (Transform weapon in transform)
        {
            if (weapon.CompareTag(tag))
            {
                GameObject o;
                (o = weapon.gameObject).SetActive(true);
                currentWeapon = o;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }

    public void DropWeapon()
    {
        if (currentWeapon!=null)
        {
             currentWeapon.SetActive(false);
        }
       
    }
}
