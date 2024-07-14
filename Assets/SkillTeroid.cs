using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTeroid : MonoBehaviour {
    public float radius;
    public float skillCost;
    public float fallSpeed;
    public Vector3 fallDirection;
    public bool active = false;
    public GameObject effect;
    public Transform target;
    public CursorScript skillCursorScript;
    public SkillPntManager skillPntManager;

    private void Start() {
        fallDirection = target.position - transform.position;
        radius = target.transform.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        if (skillPntManager == null) {
            Debug.Log("skillPntManager not found");
            return;
        }
        if (skillCursorScript == null) {
            Debug.Log("skillCursorScript not found");
            return;
        }

        if (skillCursorScript.hit.collider != null) {
            // Check if the hit object has the "Skill" tag
            if (skillCursorScript.hit.collider.CompareTag("Skill")) {
                SkillTeroid skillTeroid = skillCursorScript.hit.collider.gameObject.GetComponent<SkillTeroid>();
                if (skillTeroid != null && Input.GetMouseButtonDown(0) && skillPntManager.skillPnts >= skillTeroid.skillCost) {
                    // Activate the skill only if the component is found & you have enough skill points
                    skillTeroid.active = true;
                }
            }
        }

        if (active) {
            // Move the object along the specified direction with a certain speed
            transform.Translate(fallDirection.normalized * fallSpeed * Time.deltaTime);
        }


        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, target.position) < radius)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (active && collision.gameObject.CompareTag("Planet")) {
            Debug.Log("Active Star Effect");
            Destroy(gameObject);
        }
    }
}
