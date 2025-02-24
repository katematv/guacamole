using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    [Range(-3,4)]
    private float pitchMinimo;
    [SerializeField]
    [Range(-3, 4)]
    private float pitchMaximo;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        audioSource.pitch = Random.Range(pitchMinimo, pitchMaximo);
        audioSource.Play();
    }
 
}
