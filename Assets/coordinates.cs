using UnityEngine;
using System.Collections.Generic;

public class Coordinates : MonoBehaviour {
    public Vector3[] positions; // Where the planets go
    private Vector3[] actualPos; // Where the planets go relative to the root planet
    public List<GameObject> spawnedPlanets = new List<GameObject>(); // List to keep track of spawned objects

    void Awake() {
        // Initialize actualPos with the same length as positions
        actualPos = new Vector3[positions.Length];
    }

    void Update() {
        // Update actualPos to reflect the current position of the root GameObject
        for (int i = 0; i < positions.Length; i++) {
            actualPos[i] = transform.position + positions[i];
        }

        // Update the positions of the spawned objects
        for (int i = 0; i < spawnedPlanets.Count; i++) {
            if (i < spawnedPlanets.Count && spawnedPlanets[i] != null) {
                spawnedPlanets[i].transform.position = actualPos[i];
            }
        }
    }

    public List<GameObject> getPlanets() {
        return spawnedPlanets;
    }

    public Vector3[] getCoordinates() {
        return actualPos;
    }
}
