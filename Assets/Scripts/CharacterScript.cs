using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float jumpHeight;
    public float playerVelocityY;
    private CharacterController characterController;
    private float gravityValue = -9.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = characterController.isGrounded;
        if(groundedPlayer && playerVelocityY < 0) 
        {
            playerVelocityY = 0f;
        }

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if(Mathf.Abs(dx) > 0 &&  Mathf.Abs(dy) > 0) 
        {
            dx *= 0.707f;
            dy *= 0.707f;
        }

        if(Input.GetButtonDown("Jump") && groundedPlayer) 
        {
            playerVelocityY += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        Vector3 horizontalForward = Camera.main.transform.forward;
        horizontalForward.y = 0;
        horizontalForward = horizontalForward.normalized;
        playerVelocityY += gravityValue * Time.deltaTime;

        characterController.Move(Time.deltaTime * (speed * (dx * Camera.main.transform.right + dy * horizontalForward) + playerVelocityY * Vector3.up));
        this.transform.forward = horizontalForward;
    }
}
