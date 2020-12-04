using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (EstPersonnage(tag))
        {
            Destroy(gameObject);

            GestionnairePoints
                .AddPoints((Personnage)Enum.Parse(typeof(Personnage), tag));   
        }
    }
}
