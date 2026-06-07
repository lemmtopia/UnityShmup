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

    private bool lastFire = false;

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
        move = GameInput.Instance.GetMoveActionValue();

        if (move.y == 0)
        {
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            if (move.y > 0)
            {
                animator.SetFloat("MoveY", 1);
            }
            else
            {
                animator.SetFloat("MoveY", -1);
            }
        }

        rb.linearVelocity = move.normalized * moveSpeed;

        if (GameInput.Instance.IsFireActionPressed() && !lastFire)
        {
            Instantiate(bulletPrefab, bulletSpawnPointTransform.position, Quaternion.identity);
        }

        lastFire = GameInput.Instance.IsFireActionPressed();
    }
}
