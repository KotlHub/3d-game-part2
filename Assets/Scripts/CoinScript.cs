using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("State", 1);
        }
    }

    public void OnDisappearFinish()
    {
        transform.position += Vector3.forward * 5f;
        animator.SetInteger("State", 0);
        Debug.Log("OnDisappearFinish");
    }
}
