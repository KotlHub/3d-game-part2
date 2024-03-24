using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GameObject
            .Find("GameScoreText")
            .GetComponent<TMPro.TextMeshProUGUI>();
        GameState.Subscribe(OnGameStateChanged);
    }

    private void OnGameStateChanged(string propName)
    {
        if (propName == nameof(GameState.Score))
        {
            scoreText.text = GameState.Score.ToString("0000.0");
        }
    }
    private void OnDestroy()
    {
        GameState.Unsubscribe(OnGameStateChanged);
    }

}
