using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer mesh;
    private bool vaEtreDetruit = false;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        mesh = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (!vaEtreDetruit && EstPersonnage(tag))
        {
            vaEtreDetruit = true;
            // On cache la pièce tout de suite pour donner l'impression qu'elle est détruite,
            // mais on laisse le temps à l'audio de jouer avant de détruire l'objet pour de vrai.
            mesh.enabled = false;
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);

            GestionnairePoints
                .AddPoints(GetPersonnage(tag));   
        }
    }
}
