using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{

    #region Variables
    [SerializeField] private Vector3 startPoint; // Start point of the rotation
    [Header("Movement Variables")]
    public Transform target; // The object around which the camera will orbit
    public float inputSensitivity = 150.0f; // Mouse input sensitivity
    private float mouseX, mouseY; // Mouse input values
    private float startDistance; // Initial distance between camera and target
    private bool isRotating = false; // Flag to track if rotation should occur

    [Header("Zoom Variables")]
    public float zoomSpeed = 5.0f; // Speed of zooming in and out
    public float minFOV = 20f; // Minimum field of view
    public float maxFOV = 100f; // Maximum field of view

    [Header("Zoom Variables 2")]
    public float zoom;
    public float zoomMult = 4f;
    public float minZoom = 2f;
    public float maxZoom;
    private float velocity = 0f;
    public float smoothTime = 0.25f;
    [SerializeField] public Camera cam;

    [Header("Rotation Momentum Variables")]
    public Vector3 rotation;
    public float mouseRotationX;
    public float mouseRotationY;
    public float curRotationSpeedX = 0f;
    public float curRotationSpeedY = 0f;
    public float rotationSpeed = 1f;
    public float rotationDamping = 1f;

    public Vector3 lastMousePosition; // Last recorded mouse position
    public Vector3 currentMousePosition;
    public Vector3 lastMouseV; // Last recorded mouse movement vector
    public float lastMouseS; // Last recorded mouse speed
    public float deceleration;
    #endregion

    void Start()
    {
        cam = GetComponent<Camera>();
        zoom = cam.fieldOfView;

        if (target == null)
        {
            Debug.LogError("Target not assigned for CameraOrbit script!");
            return;
        }

        //Calculate the initial distance between camera and target
        startDistance = Vector3.Distance(transform.position, target.position);

        //Hide and lock the cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        // Initialize mouseX and mouseY based on current camera rotation
        mouseX = transform.eulerAngles.y;
        mouseY = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // If the target exists, rotate the camera around it
        if (target != null && isRotating) {
            //Capture mouse input
            mouseX += Input.GetAxis("Mouse X") * inputSensitivity * Time.deltaTime;
            mouseY -= Input.GetAxis("Mouse Y") * inputSensitivity * Time.deltaTime;
            mouseY = Mathf.Clamp(mouseY, -80f, 80f); //Limit vertical rotation angle

            //Calculate rotation based on mouse input
            Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

            //Calculate the new position of the camera based on the rotation and initial distance
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -startDistance);
            Vector3 position = rotation * negDistance + target.position;

            //Update camera position and rotation
            transform.rotation = rotation;
            transform.position = position;
            startPoint = transform.position;
        } else if (target != null && !isRotating) {
            transform.rotation = transform.rotation;
            transform.position = transform.position;
            startPoint = transform.position;
        }
    }

    void Update()
    {
        scrollZoom();
        cursorShoot();
        checkMouseInput();

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float newFOV = Camera.main.fieldOfView - scroll * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
        }

        if (!isRotating)
        {
            transform.RotateAround(target.transform.position, Vector3.up, lastMouseS * Time.deltaTime);
        }

        decelerate();

    }

    void scrollZoom()
    {
        //ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        //zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        zoom -= scrollWheel * zoomMult;
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }

    private void cursorShoot()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;
        // This would cast rays only against colliders in layer 8.

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }

    private void checkMouseInput() {
        // Check if left mouse button is held down
        if (Input.GetMouseButtonDown(0)) {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        // Check if left mouse button is released
        if (Input.GetMouseButtonUp(0)) {
            isRotating = false;
            lastMouseS = CalculateMouseSpeed();
            lastMouseV = CalculateMouseVector();
        }
    }

    public float CalculateMouseSpeed() {
        // Mouse speed calculation based on the change in mouse position
        float speed = Input.GetAxis("Mouse X") / Time.deltaTime;
        speed = Mathf.Clamp(speed, -300f, 300f); //Limit speed
        return speed;
    }

    public Vector3 CalculateMouseVector() {
        // Mouse movement vector calculation based on the change in mouse position
        currentMousePosition = Input.mousePosition;
        Vector3 mouseVector = currentMousePosition - lastMousePosition;
        return mouseVector;
    }

    public void decelerate() {
        if (!isRotating && lastMouseS > 0) {
            lastMouseS -= deceleration * Time.deltaTime;
        } else if (!isRotating && lastMouseS < 0) {
            lastMouseS += deceleration * Time.deltaTime;
        }
    }

}