using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickMechanism : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] ProgressBar prog = null;
    [SerializeField] private bool kickFlag = false;
    [SerializeField] float annoyance_inc = 0.1f;

    [SerializeField] AudioClip kickSound = null;
    private AudioSource audioSource = null;

    public float GetAnnoyanceInc()
    {
        return annoyance_inc;
    }
    public void PlayKickSound()
    {
        if (audioSource != null)
        {

            audioSource.PlayOneShot(kickSound);
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            kickFlag = true;
            PlayKickSound();
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            kickFlag = false;
        }
    }

    // void Kick_handler()
    // {
    //     kickFlag = true;
    // }

    public bool GetKickFlag()
    {
        return kickFlag;
    }
}
