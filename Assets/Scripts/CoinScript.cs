using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObj;

    private List<GameObject> childObjects = new List<GameObject>();

    private int currentObj = 0;

    private Animator _animator;
    const float minSpawnOffset = 50f;
    float minSpawnDistance = 20f;
    float maxSpawnDistance = 30f;
    float maxHeightFactor = 1.5f;
    float minHeightFactor = 0.7f;
    float initialCoinHeight;
    void Start()
    {
        for (int i = 0; i < parentObj.transform.childCount; i++)
        {
            childObjects.Add(parentObj.transform.GetChild(i).gameObject);
        }

        _animator = GetComponent<Animator>();
        GameState.Subscribe(OnGameStateChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetInteger("State", 1);

        }
    }
    public void OnDisappearFinish()
    {
        GameState.Score += GameState.CoinCost;
        //Debug.Log("OnDisappearFinish");
        Respawn();
        GameState.AddGameMessage(new() { Text = $"Earned {GameState.CoinCost:F1} scores" });
        _animator.SetInteger("State", 0);
    }
    private void Respawn()
    {
        currentObj++;
        Vector3 newPosition = new Vector3(childObjects[currentObj].transform.position.x,
                                          childObjects[currentObj].transform.position.y + 2,
                                          childObjects[currentObj].transform.position.z);

        transform.position = newPosition;

    }

    private void OnGameStateChange(string propName)
    {
        if (propName == nameof(GameState.CoinCost))
        {
            Respawn();
            GameState.AddGameMessage(new() { Text = $"Coin has been replaced. New price: {GameState.CoinCost:F1}" });
        }
    }
    private void OnDestroy()
    {
        GameState.Unsubscribe(OnGameStateChange);

    }
}
