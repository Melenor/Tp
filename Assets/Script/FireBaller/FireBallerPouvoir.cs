using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallerPouvoir : MonoBehaviour, Pouvoir
{
    [SerializeField] private GameObject projectile = default;
    [SerializeField] private Transform positionCannon = default;
    [SerializeField] private int forcePropulsion = 1000;

    public void UtiliserPouvoir()
    {
        GameObject copieProjectile = Instantiate(projectile);
        copieProjectile.GetComponent<MeshRenderer>().enabled = true;
        copieProjectile.transform.position = positionCannon.position + transform.forward;
        copieProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * forcePropulsion);
    }
}
