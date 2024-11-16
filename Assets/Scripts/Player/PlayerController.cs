using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float interactionRange = 3f;
    private Rigidbody rb;

    private Vector3 inputVector;
    private bool inputSprint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        inputVector = new Vector3(inputHorizontal, 0, inputVertical);

        inputSprint = Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKeyDown(KeyCode.E)) ManualInteract();
    }
    void FixedUpdate()
    {
        float inputMagnitude = Mathf.Clamp01(inputVector.magnitude);
        Vector3 inputDirection = inputVector.normalized;

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;
        Vector3 movement = movementDirection * inputMagnitude * (inputSprint? sprintSpeed : speed);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
    private void ManualInteract()
    {
        RaycastHit hit;
        Vector3 rayOrigin = cameraTransform.position;
        Vector3 rayDirection = cameraTransform.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, interactionRange))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.ManualInteract();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>())
        {
            other.GetComponent<Interactable>().OnTriggerEnterInteract();
        }
    }
}
