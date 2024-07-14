using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class charMove : MonoBehaviour {

    public Transform planet; // The center of the sphere
    public float slerpTime;
    public float timeLimit = 5.0f;
    
    public float timer;
    private Vector3 targetPoint; // The point on the sphere to rotate to
    private bool isMovingToTarget = false; // Whether the player is moving towards the target point
    


    void Update() {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            timer = 0;
            // If the ray hits the sphere
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.CompareTag("Planet")) {
                    // Set the target point to the hit point
                    targetPoint = hit.point;
                    isMovingToTarget = true;
                }
            }
        }

        // If the player is moving to the target point
        if (isMovingToTarget) {
            transform.position = Vector3.Slerp(transform.position, targetPoint, Time.deltaTime * slerpTime);


            timer += Time.deltaTime;
            if (timer >= timeLimit) {
                transform.position = targetPoint;
            }

            // Check if the player has reached the target point
            if (Vector3.Distance(transform.position, targetPoint) < 0.5f) {
                transform.position = targetPoint;
                timer = 0;
                isMovingToTarget = false;
            }
        }
    }
}
