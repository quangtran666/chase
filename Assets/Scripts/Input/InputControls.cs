using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputControls", menuName = "Input/InputControl", order = 0)]
public class InputControls : ScriptableObject, GameControls.IGameplayActions
{
    private GameControls gameControls;
    
    public Vector2 MoveInput { get; private set; }
    
    private void OnEnable()
    {
        gameControls = new GameControls();
        gameControls.Gameplay.SetCallbacks(this);
        gameControls.Enable();
    }

    private void OnDestroy()
    {
        gameControls.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
