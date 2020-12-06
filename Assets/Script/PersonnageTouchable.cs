using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class PersonnageTouchable : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float steeringInitial;
    private CarController carController;
    private float cooldown = 0f;
    private float delaiGlace = 0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        carController = GetComponent<CarController>();
        steeringInitial = carController.Steering;
    }

    public void ToucheGlace(float duree)
    {
        delaiGlace = duree;
        cooldown = Time.time;
        carController.Steering = 0.01f;
    }

    public void ToucheFeu(Vector3 force)
    {
        rigidbody.AddForceAtPosition(force, transform.position, ForceMode.Force);
    }

    public void ToucheMine(float forceExplosion, float rayon, float modificateur)
    {
        rigidbody.AddExplosionForce(forceExplosion, transform.position, rayon, modificateur, ForceMode.Force);
        //transform.Rotate(new Vector3(10, 0, 0));
    }

    private void Update()
    {
        if (Time.time - cooldown > delaiGlace && carController.Steering != steeringInitial)
        {
            carController.Steering = steeringInitial;
        }
    }
}
