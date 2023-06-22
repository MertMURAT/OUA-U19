using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    string Npc_name;
    public void Interaction()
    {
        Debug.Log(Npc_name);
    }

    public string getName()
    {
        return Npc_name;
    }
}
