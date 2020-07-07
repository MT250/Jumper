using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}