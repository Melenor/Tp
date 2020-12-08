using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;

public class Boost : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private int boost = 10_000;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (EstPersonnage(tag))
        {
            audioSource.PlayOneShot(audioSource.clip);
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.transform.forward * boost, ForceMode.Acceleration);
        }
    }
}
