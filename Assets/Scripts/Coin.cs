using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Coin ba��na artacak skor miktar�

    private void OnTriggerEnter(Collider other)
    {
        // �arp��an objenin Player olup olmad���n� kontrol et
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!"); // Konsola mesaj yazd�r
            GameManager.Instance.AddScore(scoreValue); // Skoru art�r
            Destroy(gameObject); // Coin'i yok et
        }
    }
}
