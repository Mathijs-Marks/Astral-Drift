using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private BaseGunBarrel[] weapons = new BaseGunBarrel[2];

    [SerializeField] private bool relativeControls = true;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float yOffset = 0.5f; // Use this value to put the player a bit higher

    public Vector3 targetPosition;
    private Vector3 direction;
    private Vector3 inputPositionToPlayer;

    private bool mousePointer;
    [SerializeField] private float distanceToTarget;

    private Vector2 clampSpace;

    private void Awake()
    {
        GlobalReferenceManager.PlayerScript = this;
        GlobalReferenceManager.PlayerPosition = transform;
    }

    private void Start()
    {
        targetPosition = transform.position;

        clampSpace = new Vector2(GlobalReferenceManager.ScreenCollider.sizeX, GlobalReferenceManager.ScreenCollider.sizeY);
        clampSpace /= 2;
    }

    // Controls
    private void Update()
    {
        mousePointer = EventSystem.current.IsPointerOverGameObject();

        GetInput();
    }

    // Moving and shooting
    private void FixedUpdate()
    {
        // Moving
        direction = targetPosition - transform.position;

        // Check if the player is close enough to the desired position
        if (direction.magnitude > playerSpeed * distanceToTarget)
        {
            direction.Normalize();
            transform.Translate(direction * playerSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = targetPosition;
        }
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0)) // Note: GetMouseButtonDown also works on mobile.
        {
            if (relativeControls)
            {
                inputPositionToPlayer = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                inputPositionToPlayer = Camera.main.ScreenToWorldPoint(inputPositionToPlayer);
                inputPositionToPlayer -= transform.position;
                inputPositionToPlayer = -inputPositionToPlayer;
            }
        }
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            GetTargetPositionWorldSpace();
        }
        if (Input.touches.Length > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            targetPosition = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 0);
            GetTargetPositionWorldSpace();
        }
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = transform.position;
        }
    }

    private void GetTargetPositionWorldSpace()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);

        if (!relativeControls)
        {
            targetPosition.y += yOffset;
            inputPositionToPlayer = Vector3.zero;
        }

        inputPositionToPlayer = new Vector3(
            Mathf.Clamp(targetPosition.x + inputPositionToPlayer.x, -clampSpace.x, clampSpace.x),
            Mathf.Clamp(targetPosition.y + inputPositionToPlayer.y, -clampSpace.y + Camera.main.transform.position.y, clampSpace.y + Camera.main.transform.position.y), 
            0) - targetPosition;

        targetPosition += inputPositionToPlayer;

        targetPosition.z = 0;
    }

    public void InscreaseShootingSpeed(float amount)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].IncreaseShootingSpeed(amount);
        }
    }
}
