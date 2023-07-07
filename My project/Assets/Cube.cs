using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject TriggerCollider;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plane"))
        {
            anim.SetBool("Move", true);
            TriggerCollider.SetActive(false);
        }



    }

}
