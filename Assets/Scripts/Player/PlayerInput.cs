using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Game Components")]
    [SerializeField] private PlayerInputActions gameControls;
    private PlayerMover characterController;
    
    private void Awake()
    {
        characterController = GetComponent<PlayerMover>();
        gameControls = new PlayerInputActions();
    }
    
    private void OnEnable()
    {
        gameControls?.Enable();
    }
    
    private void OnDisable()
    {
        gameControls?.Disable();
    }
    
    private void Update()
    {
        Vector2 playerDirection = gameControls.Player.Movement.ReadValue<Vector2>();
        
        if (playerDirection != Vector2.zero)
        {
            Debug.Log($"Player Direction: X={playerDirection.x}, Y={playerDirection.y}");
        }
        
        characterController.Move(playerDirection);
    }
}