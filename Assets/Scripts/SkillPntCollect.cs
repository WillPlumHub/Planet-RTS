using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPntCollect : MonoBehaviour {

    public CursorScript curScri;
    public SkillPntManager pntsRef;

    void Update() {
        if (curScri.hit.collider != null) {
            // Check if the hit object has the "SkillPnt" tag
            if (curScri.hit.collider.CompareTag("SkillPnt")) {
                if (pntsRef != null) {
                    pntsRef.skillPnts += 10f;
                } else {
                    Debug.LogError("SkillPntManager reference not found!");
                }
                //Debug.Log("Raycast hit object with tag: SkillPnt");
                Destroy(curScri.hit.collider.gameObject);
            }
        }
    }
}
/*
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SkillPnt")) {
            Debug.Log("BOOBS");
            pnts.skillPnts += 10;
            //pnts.skillPnts += other.pntAmount;
        }
    }
}*/
