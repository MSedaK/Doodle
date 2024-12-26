using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1); // Ana sahneye geri dön
    }
}