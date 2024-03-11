using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [SerializeField]
    private Light sun;  // ������� ������� �����
    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;

    private float nightFactor = .25f;   // � ������ ���� �� ������ ���
    private float dayPeriod = 20f;      // ��������� ���� � ��������
    private float dayPhase;             // ���� ���� [0..1]

    void Start()
    {
        dayPhase = 0;
        RenderSettings.skybox = daySkybox;
    }

    void Update()
    {
        dayPhase += Time.deltaTime / dayPeriod;
        if (dayPhase > 1f)
        {
            dayPhase -= 1f;
        }
        bool isNight = dayPhase > 0.25f && dayPhase < 0.75f;
        if (isNight)
        {
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }
        }
        else
        {
            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
            }
        }

        float k = LuxFactor(dayPhase);
        sun.intensity = isNight ? k * nightFactor : k;
        RenderSettings.skybox.SetFloat("_Exposure", k);
        RenderSettings.ambientIntensity = k;
    }

    // ����� ���� ������ ���������� t[0..1] 
    // 0 - ������, 0.25 - ������, 0.5 - ����, 0.75 - �������
    float LuxFactor(float t)
    {
        return (1f + Mathf.Cos(4f * Mathf.PI * t)) / 2f;
    }

    private void OnDestroy()
    {
        sun.intensity = 1f;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
        RenderSettings.ambientIntensity = 1f;
    }
}