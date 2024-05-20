using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomAnimator : MonoBehaviour
{
    private Animator animator;
    //[SerializeField] MomMeter momMeter = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator?.SetBool("isAwake", false);
        MomMeter.OnFillPercentageChanged += ChangeAnimation;
    }

    private void ChangeAnimation(float fillPercentage)
    {
        if (fillPercentage >= 0.8)
        {
            animator?.SetBool("isAwake", true);
        }
        else
        {
            animator?.SetBool("isAwake", false);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
