using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{

    public static SkyboxChanger instance;

    public Material newSkybox;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeSkybox()
    {
        RenderSettings.skybox = newSkybox;
        RenderSettings.fog = false;
    }
}
