using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mom : MonoBehaviour
{
    // [SerializeField] GameObject baby_prefab = null;
    [SerializeField] private Vector3 babyInitialPosition;
    [SerializeField] public Transform babyPrefab; // Assign the baby prefab in the Inspector
    // [SerializeField] GameObject mom_meter = null; // Assign the mommeter slider in the Inspector
    // [SerializeField] Slider mom_meter_prefab = null; // Assign the mommeter slider in the Inspector
    [SerializeField] private float meter_value = 0f;
    [SerializeField] private float aaway_distance_value = 10f; // Adjust according to your needs
    [SerializeField] public GameObject gameover_screen = null;
    [SerializeField] GameOverScript gameover_script = null;
    // private bool gameover_flag = false;


    void Awake()
    {
        gameover_screen.SetActive(false);
        GameObject gameOverObject = GameObject.FindGameObjectWithTag("game_over");
        gameover_script = gameOverObject.GetComponent<GameOverScript>();

        if (gameover_script == null)
        {
            Debug.Log("Gameover object is NULL");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the baby prefab
        babyInitialPosition = babyPrefab.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(meter_value);
        // Check if the mommeter reaches 1
        if (meter_value == 1)
        {
            Debug.Log(babyInitialPosition);
            // Calculate the distance between current position and initial position of the baby
            float distance = Vector3.Distance(babyInitialPosition, babyPrefab.position);
            Debug.Log(distance);

            // If the baby is far from the initial position, print a comment
            if (distance > aaway_distance_value) // Adjust someThresholdValue according to your needs
            {
                Debug.Log("Baby is far from initial position!");
                //gameover_screen.SetActive(true);
                gameover_script.Gameover();
                //Time.timeScale = 0;
            }
        }
    }

    public void OnSliderChanged (float value)
    {
        meter_value = value;
    }
}
