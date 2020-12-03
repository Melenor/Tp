using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GestionnairePersonnage.EstPersonnageNonImmunise(other.gameObject.tag))
        {
            Debug.Log("OnTriggerEnter Do something to " + other.gameObject.tag);
            Destroy(this);
        }
    }
}
