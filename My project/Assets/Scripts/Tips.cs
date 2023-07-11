using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public static Tips instance;

    public Animator anim1;
    public Animator anim2;

    private void Awake()
    {
        instance = this;
    }

    public void AnimateInteractTips()
    {
        StartCoroutine(TipsAnimate());
    }

    public void AnimateRunTips()
    {
        StartCoroutine(TipsAnimateRun());
    }

    IEnumerator TipsAnimate()
    {
        yield return new WaitForSeconds(5);
        anim1.SetBool("isOpen", true);
        yield return new WaitForSeconds(5);
        anim1.SetBool("isOpen", false);
    }

    IEnumerator TipsAnimateRun()
    {
        yield return new WaitForSeconds(5);
        anim2.SetBool("isOpen", true);
        yield return new WaitForSeconds(5);
        anim2.SetBool("isOpen", false);
    }
}
