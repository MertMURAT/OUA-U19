using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WasteCollect : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wastes") && Input.GetKeyDown(KeyCode.F))
        {
                Destroy(other.gameObject);
                MissionSystem.instance.AdvanceCollectWastes();
        }
    }
}
