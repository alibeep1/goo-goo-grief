using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyProximity : MonoBehaviour
{

    [SerializeField] GameObject meterPrefab = null;
    [SerializeField] Transform seatTransform = null;
    //[SerializeField] float Range = 8f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject meter = Instantiate(meterPrefab);

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            // Set the meter's parent to the Canvas
            meter.transform.SetParent(canvas.transform, false);

            // Position the meter
            meter.transform.localPosition = new Vector3(0, 2, 0); // Adjust these values as needed

            // Activate the meter
            meter.SetActive(true);
        }
        else
        {
            Debug.LogError("No Canvas found in the scene.");
        }


        meter.transform.SetParent(seatTransform, false);

        meter.transform.localPosition = new Vector3(0, 2, 0); // Adjust these values as needed
        meter.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
