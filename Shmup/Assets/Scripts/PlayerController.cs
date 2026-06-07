using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 90f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPointTransform;

    private Vector2 move;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        animator.SetFloat("MoveY", 0);
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
            animator.SetFloat("MoveY", 1);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move.y--;
            animator.SetFloat("MoveY", -1);
        }

        if (move.y == 0)
        {
            animator.SetFloat("MoveY", 0);
        }

        rb.linearVelocity = move.normalized * moveSpeed;

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, bulletSpawnPointTransform.position, Quaternion.identity);
        }
    }
}
