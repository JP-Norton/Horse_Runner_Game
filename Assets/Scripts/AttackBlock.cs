using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlock : MonoBehaviour
{
    public float pushPower = 2.0f;  // Set the horizontal force with which you want to push the object
    public float pushUpPower = 2.0f;  // Set the upward force with which you want to push the object

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)  // Check if the object we collided with has a rigidbody
        {
            Vector3 pushDirection = rb.transform.position - transform.position;  // Determine the direction to push

            pushDirection.y = pushUpPower;  // set the upward direction

            rb.AddForce(pushDirection.normalized * pushPower, ForceMode.Impulse);  // Apply the force to the rigidbody
        }
    }
}
