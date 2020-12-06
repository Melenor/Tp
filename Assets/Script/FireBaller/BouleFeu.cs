using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;

public class BouleFeu : MonoBehaviour
{
    [SerializeField] private float forceImpact = 1_000_000;
    private void OnCollisionEnter(Collision collision)
    {
        if (EstPersonnageNonImmunise(collision.gameObject.tag))
        {
            collision.gameObject.GetComponent<PersonnageTouchable>().ToucheFeu(-collision.impulse * forceImpact);
        }
        Destroy(gameObject);
    }
}
