using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SceneChanger : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendGameSessionEvent(string eventName, string payload);

    public void StartGame()
    {

        string eventName = "game_start";
        string payload = "{}";

        SendGameSessionEvent(eventName, payload);
        Debug.Log($"Game started! Event: {eventName}, Payload: {payload}");

        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        string eventName = "game_exit";
        string payload = "{\"reason\": \"user_quit\"}";

        SendGameSessionEvent(eventName, payload);
        Debug.Log($"Game exited! Event: {eventName}, Payload: {payload}");

#if UNITY_WEBGL
        Application.ExternalEval("console.log('Game Quit Triggered');");
#else
        Application.Quit();
#endif
    }
}