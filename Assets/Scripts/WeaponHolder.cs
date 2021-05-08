
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

    public int GetWeaponForce()
    {
        if (currentWeapon == null)
        {
            return 0;
        }
        
        switch (currentWeapon.tag)
        {
            case "Sword":
                return 1;
            case "Axe":
                return 2;
            case "Sheild":
                return 1;
        }

        return 0;
    }
}
