using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 90f;

    [SerializeField] private GameObject bulletPrefab;

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
        move = Vector2.zero;

        if (Keyboard.current.dKey.isPressed)
        {
            move.x++;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            move.x--;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            move.y++;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move.y--;
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        rb.linearVelocity = move.normalized * moveSpeed;
    }
}
