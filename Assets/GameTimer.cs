using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timerInSeconds = 10; // Assign this in Unity inspector

    private float countdown;

    // Define a delegate type for the event
    public delegate void TimerUpdateHandler(float timeLeft);

    // Define an event of the delegate type
    public event TimerUpdateHandler OnTimerUpdate;




    void Start()
    {
        countdown = timerInSeconds;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        // Call the event, passing the time left as an argument
        OnTimerUpdate?.Invoke(countdown);

        if (countdown <= 0)
        {
            Debug.Log("Time's up!");
            countdown = timerInSeconds; // Reset the timer
        }
    }
}
