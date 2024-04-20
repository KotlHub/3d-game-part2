using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainScript : MonoBehaviour
{
    [SerializeField] private GameObject character;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект, с которым произошло столкновение, - персонаж
        if (other.gameObject == character)
        {
            // Перезапускаем текущую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameState.Score = 0;
        }
    }
}
