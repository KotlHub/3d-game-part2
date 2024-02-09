using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;
    private Vector3 cameraAngles;
    private Vector3 cameraOffset;
    private Vector3 initialAngles;
    private Vector3 initialOffset;
    // Start is called before the first frame update
    void Start()
    {
        initialAngles = cameraAngles = this.transform.eulerAngles;
        initialOffset = cameraOffset = this.transform.position - cameraAnchor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraAngles.y += Input.GetAxis("Mouse X");
        cameraAngles.x -= Input.GetAxis("Mouse Y");
        if (Input.GetKeyUp(KeyCode.V))
        {
            cameraOffset = (cameraOffset == Vector3.zero) ?  initialOffset: Vector3.zero;
        }

    }

    private void LateUpdate()
    {
        this.transform.position = cameraAnchor.transform.position + Quaternion.Euler(0, cameraAngles.y - initialAngles.y, 0) * cameraOffset;
        this.transform.eulerAngles = cameraAngles;
    }
}
