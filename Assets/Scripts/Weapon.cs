using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;
    [SerializeField] private Transform spawnPosition;

    [Space]
    [Header("Raycast attributes:")]
    [Tooltip("Range of ray.")]
    [SerializeField] private float range;

    [Space]
    [Header("Projectile attributes:")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float force;

    [Space]
    [SerializeField] private Camera _camera;

    private float cooldown;
    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (cooldown > 0) cooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (cooldown <= 0f)
        {
            if (weaponType == WeaponType.Raycast)
            {
                //TODO: Implement raycast shooting
                cooldown = attackDelay;
            }
            else if (weaponType == WeaponType.Projectile)
            {
                var gameObj = Instantiate(projectile, spawnPosition.transform.position, spawnPosition.transform.rotation);
                gameObj.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * force);
                cooldown = attackDelay;
            }

            audioSrc.Play();
        }
    }
}

enum WeaponType
{
    Raycast,
    Projectile
}

