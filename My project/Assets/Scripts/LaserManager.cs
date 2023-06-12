using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserManager : MonoBehaviour
{
    public GameObject Laser;

    public bool isOpen=false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            isOpen = true;
            Shoot();
          

            


        }
        if(Input.GetKeyUp(KeyCode.V))
        {
            StopShooting();
            isOpen= false;
        }
    }
    void Shoot()
    {
        Laser.SetActive(true);
        
       
    }
    void StopShooting()
    {
        Laser.SetActive(false);
       
    }


   


}
