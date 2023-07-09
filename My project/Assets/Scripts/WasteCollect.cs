using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class WasteCollect : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wastes") && Input.GetKeyDown(KeyCode.F))
        {
            ThirdPersonController.instance.TriggerPickUp();
            Destroy(other.gameObject, 2f);
            MissionSystem.instance.AdvanceCollectWastes();
            StartCoroutine(EnabledInput());
        }
    }

    IEnumerator EnabledInput()
    {
        yield return new WaitForSeconds(2);
        ThirdPersonController.instance.EnableInput();

    }
}
