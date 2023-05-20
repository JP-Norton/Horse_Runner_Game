using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soccer_Net : MonoBehaviour
{
    public Coin_Manager Coin_Manager;

    // Start is called before the first frame update
    void Start()
    {
        Coin_Manager = GameObject.FindWithTag("Player").GetComponent<Coin_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoccerBall")) {
            Coin_Manager.IncrementCoinCount(10);
            Destroy(gameObject);
        }
    }
}
