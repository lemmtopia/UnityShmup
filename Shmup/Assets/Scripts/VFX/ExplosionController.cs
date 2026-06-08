using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Animator animator;
    private AudioSource sound;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        sound.Play();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
