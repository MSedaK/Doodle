using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject tcPrefab; // Tekrar TC prefab olarak deðiþtirdik
    public int platformCount = 300;
    public float tcSpawnChance = 0.5f; // TC spawn chance olarak deðiþtirdik
    public static GameManager Instance { get; private set; }
    public static int score = 0; // static score'u koruyoruz
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
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
            spawnPosition.y += Random.Range(0.5f, 3f);
            spawnPosition.x = Random.Range(-2.5f, 2.5f);

            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            if (Random.value < tcSpawnChance)
            {
                SpawnTCAbovePlatform(platform); // TC spawn metodunu çaðýrýyoruz
            }
        }
    }

    void SpawnTCAbovePlatform(GameObject platform) // Metod adýný TC olarak deðiþtirdik
    {
        Vector3 tcPosition = platform.transform.position + new Vector3(0, 0.5f, 0);
        Instantiate(tcPrefab, tcPosition, Quaternion.identity);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}