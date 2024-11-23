using Cinemachine;
using ProceduralGrass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCharactersSO characterDefs;
    [SerializeField] private Transform eyeLevelTransform;
    [SerializeField] private float eyeLevelOffset = -1;
    [SerializeField] private GrassInteractor grassInteractor;
    [SerializeField] private float grassInteractorWidthOffset = 1;
    [field: SerializeField] public Character playerCharacter { get; private set; } = Character.Rogue;
    public static event Action<Character> OnCharacterChange;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float interactionRange = 3f;

    private CapsuleCollider capsuleCollider;
    private Transform cameraTransform;
    private Rigidbody rb;

    private bool canMove = true;
    private Vector3 inputVector;
    private bool inputSprint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
        UpdateCharacter();
    }
    private void Update()
    {
        if (canMove)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            inputVector = new Vector3(inputHorizontal, 0, inputVertical);

            inputSprint = Input.GetKey(KeyCode.LeftShift);
            if (Input.GetKeyDown(KeyCode.E)) ManualInteract();
        }
        else
        {
            inputVector = Vector3.zero;
            inputSprint = false;
        }
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
        Vector3 movement = movementDirection * inputMagnitude * (inputSprint ? sprintSpeed : speed);
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
    public void SetCanMove(bool state)
    {
        canMove = state;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        CinemachineVirtualCamera camera = FindObjectOfType<CinemachineVirtualCamera>(true);
        CinemachinePOV povComponent = camera.GetCinemachineComponent<CinemachinePOV>();
        if (state)
        {
            povComponent.m_HorizontalAxis.m_InputAxisName = "Mouse X";
            povComponent.m_VerticalAxis.m_InputAxisName = "Mouse Y";
        }
        else
        {
            povComponent.m_HorizontalAxis.m_InputAxisName = "";
            povComponent.m_HorizontalAxis.m_InputAxisValue = 0;
            povComponent.m_VerticalAxis.m_InputAxisName = "";
            povComponent.m_VerticalAxis.m_InputAxisValue = 0;
        }
    }
    public void SetCharacter(Character character)
    {
        playerCharacter = character;
        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        OnCharacterChange?.Invoke(playerCharacter);
        PlayerCharacterDef characterDef = characterDefs.playerCharacters.FirstOrDefault((character) => character.character == playerCharacter);
        float characterHeight = characterDef.height;
        float characterWidth = characterDef.width;
        capsuleCollider.height = characterHeight;
        capsuleCollider.radius = characterWidth;
        capsuleCollider.center = new Vector3(0,characterHeight/2,0);
        eyeLevelTransform.localPosition = new Vector3(0, characterHeight + eyeLevelOffset, 0);
        grassInteractor.SetRadius(characterWidth + characterWidth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>())
        {
            other.GetComponent<Interactable>().OnTriggerEnterInteract();
        }
    }
}
