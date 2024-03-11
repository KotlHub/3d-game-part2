using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StaminaScript : MonoBehaviour
{
    private Image Indicator;
    // Start is called before the first frame update
    void Start()
    {
        Indicator = GameObject.Find("StaminaIndicator").GetComponent<Image>();
        GameState.Subscribe(OnGameStateChange);
    }

    // Update is called once per frame
    private void OnGameStateChange(string propName)
    {
        if(propName == nameof(GameState.CharacterStamina))
        {
            Indicator.fillAmount = GameState.CharacterStamina;
        }
    }

    private void OnDestroy()
    {
        GameState.Unsubscribe(OnGameStateChange);
    }
}
