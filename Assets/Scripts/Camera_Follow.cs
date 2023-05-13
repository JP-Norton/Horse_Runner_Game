using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Vector3 baseOffset;
    public Vector3 shiftOffset;
    public Vector3 Offset;
    public Transform target;
    public float smoothTime;
    Vector3 currentVelocity = Vector3.zero;
    public Vector3 baseCameraAngle;
    public Vector3 shiftCameraAngle;
    public float shiftCameraAngleSpeed;
    private Vector3 currentAngle;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
        Offset = baseOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        if (false)
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, shiftCameraAngle.x, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(currentAngle.y, shiftCameraAngle.y, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(currentAngle.z, shiftCameraAngle.z, Time.deltaTime * shiftCameraAngleSpeed)
            );
 
            transform.eulerAngles = currentAngle;

            Offset = shiftOffset;
        }
        else
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, baseCameraAngle.x, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(currentAngle.y, baseCameraAngle.y, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(currentAngle.z, baseCameraAngle.z, Time.deltaTime * shiftCameraAngleSpeed)
            );
 
            transform.eulerAngles = currentAngle;

            Offset = baseOffset;
        }
    }

    void LateUpdate()
    {
        
        targetPosition = new Vector3(
                Mathf.LerpAngle(targetPosition.x, target.position.x + Offset.x, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(targetPosition.y, target.position.y + Offset.y, Time.deltaTime * shiftCameraAngleSpeed),
                Mathf.LerpAngle(targetPosition.z, target.position.z + Offset.z, Time.deltaTime * shiftCameraAngleSpeed)
            );
        transform.position = targetPosition;
        // Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}
