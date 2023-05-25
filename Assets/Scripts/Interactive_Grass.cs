using UnityEngine;

public class Interactive_Grass : MonoBehaviour
{
    // Gameplay objects
    GameObject player;
    GameObject pivot;

    // Parameters for interaction
    public float lerpSpeed = 10.0f;
    public bool useSlerp = true;

    // New variable to control the strength of rotation
    public float rotationStrength = 1.0f;

    // Variables for calculations - no need for them to be public
    private float distanceX;
    private float distanceY;
    private float distanceZ;
    private float angle;
    private float angleOfRotation;
    private float angleOfRotation2;

    void Start()
    {
        // Initial setup of player and pivot
        player = GameObject.FindGameObjectWithTag("Player");
        pivot = gameObject;
    }

    void Update()
    {
        // Calculate the distances in 3D space
        distanceX = player.transform.position.x - pivot.transform.position.x;
        distanceY = Mathf.Abs(player.transform.position.y - pivot.transform.position.y);
        distanceZ = player.transform.position.z - pivot.transform.position.z;

        // Compute the angle based on the x and z distance
        angle = Mathf.Atan2(distanceZ, distanceX) * Mathf.Rad2Deg;

        // Create a stick input vector based on the distances
        Vector3 stickInput3 = new Vector3(distanceX, 0f, distanceZ);

        // Get the axis of rotation by crossing with the up vector
        Vector3 axisOfRotation = Vector3.Cross(Vector3.up, stickInput3);

        // Compute the rotation angles based on the input vector's magnitude
        angleOfRotation = Mathf.Clamp((-10 / stickInput3.magnitude), -45f, -15f);
        angleOfRotation2 = (0f + (angleOfRotation - (-15f)) * (-45f - 0f) / (-45f - (-15f)));

        // Modify angleOfRotation2 based on distance_y
        float rotationScaleFactor = Mathf.Clamp(1 - (distanceY / 2), 0.1f, 1.0f);
        angleOfRotation2 *= rotationScaleFactor;

        // Multiply angle of rotation by rotation strength
        angleOfRotation *= rotationStrength;
        angleOfRotation2 *= rotationStrength;

        // Start and end rotations for the lerp/slerp
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.AngleAxis(angleOfRotation2, axisOfRotation);

        // Apply rotation using either Lerp or Slerp based on the 'useSlerp' flag
        transform.rotation = useSlerp 
                            ? Quaternion.Slerp(startRotation, endRotation, Time.deltaTime * lerpSpeed)
                            : Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * lerpSpeed);
    }
}
