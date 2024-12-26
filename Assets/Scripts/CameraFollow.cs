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
        // Oyun baþlangýcýnda alt sýnýrý oyuncunun biraz altýnda ayarla
        bottomLimit = target.position.y - offset;
        // 0.5 saniye sonra oyunu baþlat
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

        // Sadece oyun baþladýktan sonra game over kontrolü yap
        if (gameStarted && target.position.y < bottomLimit)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }
    }
}