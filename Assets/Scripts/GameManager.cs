using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab; // Platform prefab'i
    public GameObject coinPrefab; // Coin prefab'i
    public int platformCount = 300; // Olu�turulacak platform say�s�
    public float coinSpawnChance = 0.5f; // Coin spawn olma olas�l���
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
            // Platform olu�tur
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-5f, 5f);

            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            // Coin spawn etme �ans�
            if (Random.value < coinSpawnChance)
            {
                SpawnCoinAbovePlatform(platform);
            }
        }
    }

    void SpawnCoinAbovePlatform(GameObject platform)
    {
        // Platform pozisyonunu al ve biraz yukar� kayd�r
        Vector3 coinPosition = platform.transform.position + new Vector3(0, 0.5f, 0);

        // Coin olu�tur
        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }

    public void AddScore(int value)
    {
        score += value; // Skoru art�r
        UpdateScoreUI(); // UI'y� g�ncelle
        Debug.Log("Score: " + score); // Konsola yazd�r
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // UI'daki metni g�ncelle
        }
    }
}
