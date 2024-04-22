using UnityEngine;

public class FollowTransformWithOffset : MonoBehaviour
{
    [SerializeField] Transform targetTransform = null;
    [SerializeField] float damping = 0.5f;
    [SerializeField] Vector3 offset;

    private Vector3 followVelocity = Vector3.zero;

    // There are many ways to do this. We could just add the camera transform as a child of the target object
    // or synchronize the two transform positions by code.
    // We are taking the second approach here, but with a smooth damp to make it a bit juicer.
    // https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html

    private void LateUpdate()
    {
        if (targetTransform == null) return;

        Vector3 targetPosition = targetTransform.TransformPoint(new Vector3(offset.x, offset.y, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, damping);
    }
}
