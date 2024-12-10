using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab; // Platform prefab'i
    public GameObject coinPrefab; // Coin prefab'i
    public int platformCount = 300; // Oluþturulacak platform sayýsý
    public float coinSpawnChance = 0.5f; // Coin spawn olma olasýlýðý
    public static GameManager Instance { get; private set; }
    private int score = 0; // Oyuncunun skoru
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            // Platform oluþtur
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-5f, 5f);

            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            // Coin spawn etme þansý
            if (Random.value < coinSpawnChance)
            {
                SpawnCoinAbovePlatform(platform);
            }
        }
    }

    void SpawnCoinAbovePlatform(GameObject platform)
    {
        // Platform pozisyonunu al ve biraz yukarý kaydýr
        Vector3 coinPosition = platform.transform.position + new Vector3(0, 0.5f, 0);

        // Coin oluþtur
        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }

    public void AddScore(int value)
    {
        score += value; // Skoru artýr
        UpdateScoreUI(); // UI'yý güncelle
        Debug.Log("Score: " + score); // Konsola yazdýr
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // UI'daki metni güncelle
        }
    }
}
