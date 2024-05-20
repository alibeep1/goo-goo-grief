using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public GameTimer gameTimer; // Assign this in Unity inspector
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameTimer.OnTimerUpdate += UpdateTimeDisplay;
    }

    void UpdateTimeDisplay(float timeLeft)
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        textMesh.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void OnDestroy()
    {
        // Unsubscribe when the object is destroyed to prevent memory leaks
        gameTimer.OnTimerUpdate -= UpdateTimeDisplay;
    }
}
