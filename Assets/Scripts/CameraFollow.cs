using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float bottomLimit;
    private float offset = 5f;
    private bool gameStarted = false;

    private void Start()
    {
        // Oyun ba�lang�c�nda alt s�n�r� oyuncunun biraz alt�nda ayarla
        bottomLimit = target.position.y - offset;
        // 0.5 saniye sonra oyunu ba�lat
        Invoke("StartGame", 0.5f);
    }

    private void StartGame()
    {
        gameStarted = true;
    }

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
            bottomLimit = transform.position.y - offset;
        }

        // Sadece oyun ba�lad�ktan sonra game over kontrol� yap
        if (gameStarted && target.position.y < bottomLimit)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }
    }
}