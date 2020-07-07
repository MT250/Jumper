using UnityEngine;

public class Plank : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
