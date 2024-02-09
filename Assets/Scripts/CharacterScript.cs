using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if(Mathf.Abs(dx) > 0 &&  Mathf.Abs(dy) > 0) 
        {
            dx *= 0.707f;
            dy *= 0.707f;
        }
        characterController.SimpleMove(speed * Time.deltaTime * (dx * Camera.main.transform.right + dy * Camera.main.transform.forward));

    }
}
