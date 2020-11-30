﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityStandardAssets.Vehicles.Car;

public class SelectionPersonnage : MonoBehaviour
{
    public enum Personnage { Tanky, IcerMan, FireBaller, TheTrickster }

    [SerializeField] private Personnage personnageChoisi = Personnage.Tanky;

    void Start()
    {
        GameObject joueur = GameObject.FindGameObjectWithTag(personnageChoisi.ToString());

        // Active les composants pour le user.
        joueur.GetComponentInChildren<Camera>().enabled = true;
        joueur.GetComponent<CarUserControl>().enabled = true;
        joueur.GetComponent<UserPouvoir>().enabled = true;

        // Désactive les composants AI.
        joueur.GetComponent<CarAIControl>().enabled = false;
        joueur.GetComponentInChildren<AIChampVision>().enabled = false;
        joueur.GetComponentInChildren<ConeCollider>().enabled = false;
        joueur.GetComponent<AIPouvoir>().enabled = false;
    }

    public static bool EstPersonnage(string tag) => Enum.GetNames(typeof(Personnage)).Contains(tag);
}
