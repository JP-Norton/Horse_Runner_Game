using UnityEngine;

public class Coin_Manager : MonoBehaviour 
{
    public int coinCount = 0;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Coin")) 
        {
            Destroy(other.gameObject);
            IncrementCoinCount(1);
        }
    }

    public void IncrementCoinCount(int count) {
        coinCount += count;
    }
}
