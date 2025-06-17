using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputActions inputActions;
    private PlayerMover playerMover;
    
    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        inputActions = new PlayerInputActions();
    }
    
    private void OnEnable()
    {
        inputActions?.Enable();
    }
    
    private void OnDisable()
    {
        inputActions?.Disable();
    }
    
    private void Update()
    {
        Vector2 movementInput = inputActions.Player.Movement.ReadValue<Vector2>();
        
        if (movementInput != Vector2.zero)
        {
            Debug.Log($"Movement Input: X={movementInput.x}, Y={movementInput.y}");
        }
        
        playerMover.Move(movementInput);
    }
}