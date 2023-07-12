using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class WasteCollect : MonoBehaviour
{
    public AudioClip collect;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wastes") && Input.GetKeyDown(KeyCode.F))
        {
            if (other.gameObject.CompareTag("Collected"))
            {
                return;
            }

            SoundManager.instance.PlaySoundFX(collect, 0.3f);
            ThirdPersonController.instance.TriggerPickUp();
            other.gameObject.tag = "Collected";
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
