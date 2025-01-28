using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.score = 0; // Skoru sýfýrla
        SceneManager.LoadScene(1); // Ana sahneye geri dön
    }
}