using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour {

    public int targetWidth = 320; // Target width of the resolution
    public int targetHeight = 240; // Target height of the resolution
    public bool fullscreen = false; // Whether to run in fullscreen mode

    void Start()
    {
        // Calculate the target height based on the original aspect ratio
        float originalAspect = (float)Screen.width / Screen.height;
        targetHeight = Mathf.RoundToInt(targetWidth / originalAspect);

        // Set the resolution
        SetResolution();
    }

    public void SetResolution()
    {
        Screen.SetResolution(targetWidth, targetHeight, fullscreen);
    }
}
