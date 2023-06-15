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

    //Call PlaySound method once the script is started.
    void Start()
    {
        Invoke("PlaySound", Random.Range(0, 5.0f));    
    }

    //Selects a random sound and plays it, then call itself to produce a loop.
    void PlaySound()
    {
        int randomAudioIndex = Random.Range(0, zombieSounds.Length);
        audioSource.clip = zombieSounds[randomAudioIndex];
        audioSource.Play();

        Invoke("PlaySound", audioSource.clip.length + timeBetweenSounds);
    }
}
