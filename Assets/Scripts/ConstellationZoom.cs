using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationZoom : MonoBehaviour {

    public float constellationTrigger;
    public float planetMapTrigger;
    public Camera cam;
    public GameObject constellations;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (cam.fieldOfView >= constellationTrigger) {
            constellations.SetActive(true);
        }
        else {
            constellations.SetActive(false);
        }
    }
}
