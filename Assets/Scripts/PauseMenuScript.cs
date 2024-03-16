using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private Toggle compassToggle;
    [SerializeField]
    private Toggle radarToggle;
    void Start()
    {
       OnCompassVisibleChanged(compassToggle.isOn);
       OnRadarVisibleChanged(radarToggle.isOn);
    }

    void Update()
    {
        
    }
    public void OnCompassVisibleChanged(bool value)
    {
        GameState.isCompassVisible = value;
    }
    public void OnRadarVisibleChanged(bool value)
    {
        GameState.isRadarVisible = value;
    }
}
