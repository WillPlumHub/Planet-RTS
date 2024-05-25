using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public ParticleSystem particleSystemToRotate;
    public CamRotate camScript;
    public float div;
    public float scaleSmoothTime = 0.1f; // Adjust this value for smoother scaling
    public Vector3 scaleVelocity;
    public TrailRenderer trailRenderer;
    public RaycastHit hit;
    private Vector3 targetScale;

    private void Start()
    {
        particleSystemToRotate.GetComponent<Renderer>().sortingLayerName = "cursor";
        particleSystemToRotate.GetComponent<Renderer>().sortingOrder = 1;
        trailRenderer.enabled = true;
    }

    void Update()
    {
        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit)) {
            // Draw the ray as red
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

            // Update particle system only when hit
            if (particleSystemToRotate != null)
            {
                particleSystemToRotate.transform.position = hit.point;
                particleSystemToRotate.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

                // Update target scale based on camera FOV
                float FOV = camScript.cam.orthographicSize;
                float scaleFactor = FOV / div;
                targetScale = Vector3.one * scaleFactor;

                // Smoothly adjust the scale
                particleSystemToRotate.transform.localScale = Vector3.SmoothDamp(particleSystemToRotate.transform.localScale, targetScale, ref scaleVelocity, scaleSmoothTime);
            }

            if (Input.GetMouseButton(0)) {
                trailRenderer.enabled = false;
            } else {
                trailRenderer.enabled = true;
            }
        }
        else
        {
            // If the ray doesn't hit anything, draw it as red and extend it a fixed distance
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        }
    }
}
