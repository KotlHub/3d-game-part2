using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishScript : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private int scoreToWin;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект, с которым произошло столкновение, - персонаж
        if (other.gameObject == character)
        {
            if(GameState.Score >= scoreToWin)
            {
                GameState.AddGameMessage(new() { Text = $"You won!" });
                //sleep 5 seconds

                StartCoroutine(ReloadSceneAfterDelay(5f));
                GameState.Score = 0;

                //GameState.AddGameMessage(new() { Text = $"Coin has been replaced. New price: {GameState.CoinCost:F1}" });
            }

            else
            {
                GameState.AddGameMessage(new() { Text = $"You need to earn {scoreToWin - GameState.Score} more score to win" });
            }
        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
