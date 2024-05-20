using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryMechanism : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] ProgressBar prog = null;
    [SerializeField] private bool cryFlag = false;
    [SerializeField] float annoyance_inc = 0.1f;

    [SerializeField] AudioClip crySound = null;
    private AudioSource audioSource = null;


    public float GetAnnoyanceInc()
    {
        return annoyance_inc;
    }
    public void PlayCrySound()
    {
        if (audioSource != null)
        {

            audioSource.PlayOneShot(crySound);
        }
        else
        {
            Debug.Log("AudioSource IS NULL");
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (inputActions != null)
        {
            inputActions.RegisterToButtonEvents(Button_listener);
        }
    }
    void Button_listener(IInputAction<bool> i_value, KeyCode i_keyCode)
    {
        // if (i_keyCode == KeyCode.C)
        // {
        //     Cry_handler();
        // }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cryFlag = true;
            Debug.Log("cryFlag");
            PlayCrySound();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            cryFlag = false;
        }
    }

    // void Cry_handler()
    // {
    //     cryFlag = true;
    // }

    public bool GetCryFlag()
    {
        return cryFlag;
    }
}
