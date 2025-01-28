using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // GameManager'dan son skoru al ve göster
        finalScoreText.text = " " + GameManager.score.ToString();
    }
}