using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    public Transform mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.forward;
        Vector3 cameraRight = mainCamera.right;
        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 movementDirection = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
