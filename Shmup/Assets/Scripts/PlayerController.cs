using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 90f;

    private Vector2 move;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 newPos = transform.position;

        if (Keyboard.current.dKey.isPressed)
        {
            newPos.x += moveSpeed * Time.deltaTime;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            newPos.x -= moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            newPos.y += moveSpeed * Time.deltaTime;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            newPos.y -= moveSpeed * Time.deltaTime;
        }

        rb.MovePosition(newPos);
    }
}
