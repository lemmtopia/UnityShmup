using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    
    private InputActions inputActions;
 
    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Enable();
    }

    private void OnDestroy()
    {
        inputActions.Disable();
    }

    public bool IsFireActionPressed()
    {
        return inputActions.Player.Fire.IsPressed();
    }

    public bool IsConfirmActionPressed()
    {
        return inputActions.Player.Confirm.IsPressed();
    }

    public bool IsCancelActionPressed()
    {
        return inputActions.Player.Cancel.IsPressed();
    }

    public Vector2 GetMoveActionValue()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
}
