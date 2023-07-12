using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlatformPuzzle : MonoBehaviour
{
    public GameObject brokenGlass, player;
    public Transform resetPos;
    ThirdPersonController controller;
    public AudioClip broke;

    private void Start()
    {
        controller = player.GetComponent<ThirdPersonController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("WrongPlatform"))
        {
            GameObject clone = (GameObject) Instantiate(brokenGlass, hit.gameObject.transform.position, hit.gameObject.transform.rotation);
            Destroy(hit.gameObject);
            Destroy(clone, 3f);
            StartCoroutine(ResetPos());
            SoundManager.instance.PlaySoundFX(broke, 0.3f);
        }
        else if (hit.gameObject.CompareTag("DeathArea"))
        {
            StartCoroutine(ResetPos());
        }
        else
        {
            return;
        }
    }


    IEnumerator ResetPos()
    {
        controller.enabled = false;
        yield return new WaitForSeconds(0.2f);
        player.transform.position = resetPos.transform.position;
        yield return new WaitForSeconds(0.2f);
        controller.enabled = true;
    }
}

