using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1f;
    [Space]
    [SerializeField] private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(cam.transform.position, cam.transform.forward, interactionDistance);
            Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.cyan, 5f);
        }
    }
}
