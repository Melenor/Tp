using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class PersonnageTouchable : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float steeringInitial;
    private CarController carController;
    private float cooldownFeu = 0f;
    private float cooldownGlace = 0f;
    private float dureeGlace = 0f;
    private MeshRenderer[] meshRoues;
    private Material materielInitialRoue;

    [SerializeField] private Material materielRoueGlace;
    [SerializeField] private ParticleSystem particulesFeu;
    [SerializeField] private float dureeFeu = 12f;
    [SerializeField] private AudioSource audioSourceFeu;
    [SerializeField] private AudioSource audioSourceGlace;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        carController = GetComponent<CarController>();
        steeringInitial = carController.Steering;
        meshRoues = carController.WheelMeshes;
        materielInitialRoue = meshRoues[0].material;
    }

    public void ToucheGlace(float duree)
    {
        audioSourceGlace.PlayOneShot(audioSourceGlace.clip);
        dureeGlace = duree;
        cooldownGlace = Time.time;
        carController.Steering = 0.01f;
        foreach (MeshRenderer mesh in meshRoues)
            mesh.material = materielRoueGlace;
    }

    public void ToucheFeu(Vector3 force)
    {
        audioSourceFeu.PlayOneShot(audioSourceFeu.clip);
        cooldownFeu = Time.time;
        if (!particulesFeu.isPlaying)
            particulesFeu.Play();
        rigidbody.AddForceAtPosition(force, transform.position, ForceMode.Force);
    }

    public void ToucheMine(float forceExplosion, float rayon, float modificateur, Vector3 rotation)
    {
        rigidbody.AddExplosionForce(forceExplosion, transform.position, rayon, modificateur, ForceMode.Force);
        transform.Rotate(rotation);
    }

    private void Update()
    {
        if (Time.time - cooldownGlace > dureeGlace && carController.Steering != steeringInitial)
        {
            carController.Steering = steeringInitial;
            foreach (MeshRenderer mesh in meshRoues)
                mesh.material = materielInitialRoue;
        }

        if (particulesFeu.isPlaying && Time.time - cooldownFeu > dureeFeu)
            particulesFeu.Stop();
    }
}
