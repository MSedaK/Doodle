using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class RestartManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendGameSessionEvent(string eventName, string payload);

    public void RestartGame()
    {
        string eventName = "game_fail";
        string payload = "{\"score\": " + GameManager.score + "}"; 

#if UNITY_WEBGL && !UNITY_EDITOR
        SendGameSessionEvent(eventName, payload);
#else
        Debug.Log($"Simulated Event: {eventName}, Payload: {payload}");
#endif

        Debug.Log("Game failed! Restarting...");

        GameManager.score = 0;
        SceneManager.LoadScene(1);
    }
}
