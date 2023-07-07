using UnityEngine;
using System.Collections;

public class FloatingController : MonoBehaviour
{

    public static FloatingController instance;
    public void DisableCollider()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
