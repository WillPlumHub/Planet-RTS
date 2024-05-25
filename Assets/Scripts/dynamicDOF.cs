using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class dynamicDOF : MonoBehaviour
{
    public Transform targetObject; // The target object to focus on
    public float focusSpeed = 5f; // Speed of focus adjustment
    public float minFocusDistance = 1f; // Minimum focus distance
    public float maxFocusDistance = 100f; // Maximum focus distance

    private DepthOfField depthOfFieldEffect; // Reference to the Depth of Field effect

    void Start()
    {
        // Get the Depth of Field effect from the Post-Processing Profile
        depthOfFieldEffect = GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>();
    }

    void Update()
    {
        if (targetObject != null && depthOfFieldEffect != null)
        {
            // Calculate the distance between the camera and the target object
            float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);

            // Clamp the distance within the min and max focus distance
            float clampedDistance = Mathf.Clamp(distanceToTarget, minFocusDistance, maxFocusDistance);

            // Smoothly adjust the focus distance towards the clamped distance
            depthOfFieldEffect.focusDistance.value = Mathf.Lerp(depthOfFieldEffect.focusDistance.value, clampedDistance, Time.deltaTime * focusSpeed);
        }
    }
}
