using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainScript : MonoBehaviour
{
    [SerializeField] private GameObject character;

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������, � ������� ��������� ������������, - ��������
        if (other.gameObject == character)
        {
            // ������������� ������� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameState.Score = 0;
        }
    }
}
