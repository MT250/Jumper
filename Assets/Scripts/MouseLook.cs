using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float lookSpeed = 3;
    [SerializeField] private float minClamp = -15f;
    [SerializeField] private float maxClamp = 15f;

    [SerializeField] private Camera viewCamera;
    private Vector2 rotation = Vector2.zero;
    public void Look()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, minClamp, maxClamp);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        viewCamera.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    private void OnEnable()
    {
        viewCamera = GetComponentInChildren<Camera>();
        CursorController.LockCursor();
    }

    private void Update()
    {
        Look();
    }

}
