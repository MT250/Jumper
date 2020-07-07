using UnityEngine;

public class JumpDetection : MonoBehaviour
{
    [SerializeField] private BasicController controller;

    private void Awake()
    {
        controller = GetComponentInParent<BasicController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.transform.name);
        controller.AllowJumping();

        if (other.gameObject.CompareTag("Platform"))
        {
            AttachPlayerToObject(other.transform);
        }
        else
        {
            DeattachPlayerFromObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DeattachPlayerFromObject();
    }

    private void AttachPlayerToObject(Transform gameObj)
    {
        controller.transform.SetParent(gameObj.transform);
    }

    private void DeattachPlayerFromObject()
    {
        controller.transform.parent = null;
    }

}
