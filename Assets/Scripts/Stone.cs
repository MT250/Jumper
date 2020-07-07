using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc;
    private void OnEnable()
    {
        if (!audioSrc) audioSrc = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSrc.Play();
    }
}
