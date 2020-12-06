﻿using UnityEngine;
using static GestionnairePersonnage;

[RequireComponent(typeof(Pouvoir))]
public class AIPouvoir : MonoBehaviour
{
    private Pouvoir pouvoir;


    void Awake()
    {
        pouvoir = GetComponent<Pouvoir>();
    }

    public void OnChampVisionTriggerEnter(Collider other)
    {
        if (EstPersonnage(other.tag))
        {
            pouvoir.UtiliserPouvoir();
        }
    }
}
