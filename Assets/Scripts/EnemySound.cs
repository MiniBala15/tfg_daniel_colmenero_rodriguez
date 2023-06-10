using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] float timeBetweenSounds = 5f;
    [SerializeField] AudioClip[] zombieSounds;

    [SerializeField] AudioSource audioSource;
    
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Invoke("PlaySound", Random.Range(0, 5.0f));    
    }

    void PlaySound()
    {
        int randomAudioIndex = Random.Range(0, zombieSounds.Length);
        audioSource.clip = zombieSounds[randomAudioIndex];
        audioSource.Play();

        Invoke("PlaySound", audioSource.clip.length + timeBetweenSounds);
    }
}
