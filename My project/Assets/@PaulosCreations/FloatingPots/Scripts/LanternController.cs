using System.Collections;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public float maxLightIntencity, minLightIntencity;
    public bool lightsEnabledOnStart;

    public Light myLight;
    private bool lightOn, flickerLight;
    private float wantedLightIntencity;
    private Coroutine animateLights;

    void Start()
    {
        if (lightsEnabledOnStart)
            ToggleLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerLight)
        {

            if (wantedLightIntencity == 0 && myLight.intensity <= 0)
            {
                myLight.enabled = false;
                flickerLight = false;
            }
            else myLight.intensity = Mathf.MoveTowards(myLight.intensity, wantedLightIntencity, Time.deltaTime * 0.6f);
        }
    }

    private IEnumerator FlickerLight()
    {
        while (lightOn)
        {
            wantedLightIntencity = Random.Range(minLightIntencity, maxLightIntencity);
            yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        }
    }
    public void ToggleLight()
    {
        lightOn = !lightOn;
        if (lightOn)
        {
            myLight.enabled = true;
            animateLights = StartCoroutine(FlickerLight());
            flickerLight = true;
        }
        else
        {
            StopCoroutine(animateLights);
            wantedLightIntencity = 0;
        }
    }
}
