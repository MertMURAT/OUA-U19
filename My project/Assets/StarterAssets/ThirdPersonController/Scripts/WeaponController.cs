using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSteath;

    GameObject currentWeaponInHand;
    GameObject currentWeaponInSteath;
    void Start()
    {
       currentWeaponInSteath = Instantiate(weapon, weaponSteath.transform);
    }

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSteath);
    }

    public void SheathWeapon()
    {
        currentWeaponInSteath = Instantiate(weapon, weaponSteath.transform);
        Destroy(currentWeaponInHand);

    }

    
    

    
}
