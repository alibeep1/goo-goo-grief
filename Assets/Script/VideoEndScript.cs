using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Drag your Video Player here
    [SerializeField] string nextSceneName; // Name of the scene to load

    void Start()
    {
        // Add a listener to the video player to detect when it finishes playing
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene(nextSceneName);
    }
}
