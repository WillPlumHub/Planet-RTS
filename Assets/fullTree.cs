using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullTree : MonoBehaviour {

    public List<GameObject> childrenList = new List<GameObject>();
    private bool messageSent = false;

    void Start() {
        foreach (Transform child in transform) {
            childrenList.Add(child.gameObject);
        }
    }

    void Update() {
        // Check if the message has already been sent
        if (!messageSent) {
            // Check if there are any children remaining in the list
            bool allDestroyed = true;
            foreach (GameObject child in childrenList) {
                if (child != null) {
                    allDestroyed = false;
                    messageSent = false;
                    break;
                }
            }

            // If all objects are destroyed, send the debug message and set the flag
            if (allDestroyed) {
                Debug.Log("Crashed all of the constellation");
                messageSent = true;
            }
        }
    }
}