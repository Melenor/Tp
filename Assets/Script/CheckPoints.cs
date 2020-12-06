using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GestionnaireCheckPoints;
using static GestionnairePersonnage;

public class CheckPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!EstPersonnage(other.tag)) return;

        Personnage personnage = GetPersonnage(other.tag);
        
        if (EstCheckPointActuel(personnage, transform))
            AccedeNouveauCheckPoints(personnage);
    }
}
