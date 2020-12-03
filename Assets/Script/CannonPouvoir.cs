using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPouvoir : MonoBehaviour, Pouvoir
{
    [SerializeField] private GameObject projectile = default;
    [SerializeField] private Transform positionCannon = default;
    [SerializeField] private int forcePropulsion = 1000;
    private float cooldown = 0f;
    private float delaiTir = 2f;

    public void UtiliserPouvoir()
    {
        if (Time.time - cooldown > delaiTir)
        {
            GameObject copieProjectile = Instantiate(projectile);
            copieProjectile.GetComponent<MeshRenderer>().enabled = true;
            copieProjectile.transform.position = positionCannon.position + positionCannon.transform.forward;
            copieProjectile.GetComponent<Rigidbody>().AddForce(positionCannon.transform.forward * forcePropulsion);
            cooldown = Time.time;
        }
    }
}
