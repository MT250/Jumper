using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;
    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed);
    }
}
