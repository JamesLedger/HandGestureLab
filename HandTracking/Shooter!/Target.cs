using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public AudioClip destroySound;
    public float volume = 1;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(destroySound, transform.position, volume);
        Destroy(gameObject);
    }
}
