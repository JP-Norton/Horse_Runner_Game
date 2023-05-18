using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Set the speed of the player
    public float dragSpeed = 10f; // Set the speed of the dragging
    public float horizontalLimit = 2.1f; // Set the horizontal limit for the player movement

    private Vector3 targetPosition;
    private Animator animator; // Declare a variable to reference the Animator component

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>(); // Assign the Animator component to the animator variable
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player forward at a constant speed
        transform.position += Vector3.forward * speed * Time.deltaTime;

        // If the mouse button is down
        if (Input.GetMouseButton(0))
        {
            // Get mouse position in screen space, where (0,0) is the bottom-left of the screen and (1,1) is the top-right of the screen
            Vector3 mousePos = Input.mousePosition;

            // Map the x position of the mouse from screen space to a position in world space, from -horizontalLimit to horizontalLimit
            float targetX = Mathf.Lerp(-horizontalLimit, horizontalLimit, mousePos.x / Screen.width);

            // Set the player's target x position to the calculated target x position, preserving the y and z coordinates
            targetPosition.x = targetX;
        }
        
        // If the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Trigger the Attack animation
            animator.SetTrigger("AttackTrigger");
        }

        // Smoothly move the player towards the target position
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);
    }
}
