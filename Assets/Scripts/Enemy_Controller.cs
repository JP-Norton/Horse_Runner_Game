using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 3f; // Set the speed of the enemy

    private float distance = 0f; // Set the distance an enemy has moved
    public int destroyAtXDistance = 40; // The distance an enemy can move before destroyed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the right at a constant speed
        Vector3 position = gameObject.transform.position;
        position.x += speed * Time.deltaTime;
        gameObject.transform.position = position;

        // Update distance enemy has moved since spanwed
        distance += speed * Time.deltaTime;
        
        if (distance >= destroyAtXDistance) {
            Destroy(gameObject);
        }
    }
}
