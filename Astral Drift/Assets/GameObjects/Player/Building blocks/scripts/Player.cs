using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private BaseGunBarrel[] weapons = new BaseGunBarrel[2];

    [SerializeField] private bool relativeControls = true;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float yOffset = 0.5f; // Use this value to put the player a bit higher

    public Vector3 targetPosition; // Position the player will fly to
    private Vector3 direction; // Direction from player to target position
    private Vector3 inputPositionToPlayer; // Initial position of input for relative controls

    private bool mousePointer;
    [SerializeField] private float distanceToTarget;

    private Vector2 clampSpace; // Clamping values
    
    private void Awake()
    {
        // Initialize values of the global reference manager
        GlobalReferenceManager.PlayerScript = this;
        GlobalReferenceManager.PlayerPosition = transform;
    }

    private void Start()
    {
        // Initialize values
        targetPosition = transform.position;
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        // Clamp space is equal to the size of the camera's view space
        clampSpace = new Vector2(GlobalReferenceManager.ScreenCollider.sizeX - boxCollider.size.x, GlobalReferenceManager.ScreenCollider.sizeY - boxCollider.size.y - yOffset);
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
            // Move towards target position
            direction.Normalize();
            transform.Translate(direction * playerSpeed * Time.deltaTime);
        }
        else
        {
            // Player is now exactly on the target position
            transform.position = targetPosition;
        }
    }

    private void GetInput()
    {
        // Note: GetMouseButtonDown also works on mobile.
        if (Input.GetMouseButtonDown(0)) 
        {
            if (relativeControls)
            {
                // Get initial position of the input and translate it to world point
                inputPositionToPlayer = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                inputPositionToPlayer = Camera.main.ScreenToWorldPoint(inputPositionToPlayer);
                inputPositionToPlayer -= transform.position;
                inputPositionToPlayer = -inputPositionToPlayer; // Invert value for later usage
            }
        }
        // Get target position for PC
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            GetTargetPositionWorldSpace();
        }
        // Get target position for mobile. This code also makes sure to only take the first finger input
        if (Input.touches.Length > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            targetPosition = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 0);
            GetTargetPositionWorldSpace();
        }
        // Stop moving without inputs
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = transform.position;
        }
    }

    private void GetTargetPositionWorldSpace()
    {
        // Translate target position to world point
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);

        // If we aren't using relative controls, add an offset
        if (!relativeControls)
        {
            targetPosition.y += yOffset;
            inputPositionToPlayer = Vector3.zero;
        }

        // Clamp the player to the camera
        inputPositionToPlayer = new Vector3(
            Mathf.Clamp(targetPosition.x + inputPositionToPlayer.x, -clampSpace.x + Camera.main.transform.position.x, clampSpace.x + Camera.main.transform.position.x),
            Mathf.Clamp(targetPosition.y + inputPositionToPlayer.y, -clampSpace.y + Camera.main.transform.position.y, clampSpace.y + Camera.main.transform.position.y), 
            0) - targetPosition;

        // If we're using relative controls, add a vector from the finger to the target of the first input (otherwise input position to player is zero)
        targetPosition += inputPositionToPlayer;

        targetPosition.z = 0; // Reset z
    }

    public void InscreaseShootingSpeed(float amount)
    {
        // Increase all shooting speeds of the barrels of the player
        for (int i = 0; i < weapons.Length; i++)
        {
            float shootingSpeedChange = weapons[i].ShootingRate * amount;
            weapons[i].IncreaseShootingSpeed(shootingSpeedChange);
        }
    }
}
