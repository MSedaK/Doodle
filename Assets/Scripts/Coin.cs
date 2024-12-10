using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Coin baþýna artacak skor miktarý

    private void OnTriggerEnter(Collider other)
    {
        // Çarpýþan objenin Player olup olmadýðýný kontrol et
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!"); // Konsola mesaj yazdýr
            GameManager.Instance.AddScore(scoreValue); // Skoru artýr
            Destroy(gameObject); // Coin'i yok et
        }
    }
}
