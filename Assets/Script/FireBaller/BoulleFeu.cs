using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulleFeu : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (GestionnairePersonnage.EstPersonnageNonImmunise(collision.gameObject.tag))
        {
            Debug.Log("Do something to " + collision.gameObject.tag);
        }
        Destroy(this);
    }
}
