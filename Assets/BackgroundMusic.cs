using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private float initPitch;
    [SerializeField] MomMeter momMeter = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        initPitch = audioSource.pitch;
        // Subscribe to the OnFillPercentageChanged event
        MomMeter.OnFillPercentageChanged += AdjustPitch;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnFillPercentageChanged event when the GameObject is destroyed
        MomMeter.OnFillPercentageChanged -= AdjustPitch;
    }

    private void AdjustPitch(float fillPercentage)
    {
        if (fillPercentage < 0.5)
        {
            audioSource.pitch = initPitch;
            return;
        }
        // Calculate the target pitch using an exponential function
        float targetPitch = Mathf.Pow(2, fillPercentage);

        // Use Lerp to smoothly transition from current pitch to target pitch
        audioSource.pitch = Mathf.Lerp(audioSource.pitch, targetPitch, 0.00001f);
    }


    //private void AdjustPitch(float fillPercentage)
    //{
    //    if (fillPercentage < 0.5)
    //    {
    //        audioSource.pitch = initPitch;
    //        return;
    //    }
    //    // Calculate the target pitch using an exponential function
    //    float targetPitch = Mathf.Pow(2, fillPercentage);

    //    // Calculate the difference between the current pitch and the target pitch
    //    float pitchDifference = targetPitch - audioSource.pitch;

    //    // Adjust the pitch by a small proportion of the difference
    //    audioSource.pitch += pitchDifference * 0.0001f;
    //}




}
