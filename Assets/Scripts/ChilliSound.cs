using System;
using UnityEngine;

public class ChilliSound : MonoBehaviour
{
    private AudioSource audioSource;
    private Collider2D _collider;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _collider.enabled = false;
            audioSource.Play();
        }
    }
}
