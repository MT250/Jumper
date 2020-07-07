using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
                     private Vector3 startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private float speed;

    private bool reverse;

    void Awake()
    {
        startPosition = transform.position;

        if (endPosition.Equals(null)) Debug.LogWarning("Target position is not assigned!");
        else endPosition.SetParent(null);
    }

    void FixedUpdate()
    {
        if (!reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, speed * Time.fixedDeltaTime);
            if (transform.position.Equals(endPosition.position)) reverse = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.fixedDeltaTime);
            if (transform.position.Equals(startPosition)) reverse = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, .5f);
        Gizmos.DrawCube(endPosition.position, transform.localScale);
        Gizmos.DrawLine(transform.position, endPosition.position);
    }
}
