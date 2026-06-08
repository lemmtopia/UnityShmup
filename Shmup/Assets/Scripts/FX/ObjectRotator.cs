using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    [SerializeField] private Vector3 rotationDirection;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotationDirection.normalized * rotationSpeed * Time.deltaTime);
    }
}
