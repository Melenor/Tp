﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.Vehicles.Car;

public class SelectionPersonnage : MonoBehaviour
{
    internal enum Personnage { Tanky, IcerMan, FireBaller, TheTrickster }

    [SerializeField] private Personnage personnageChoisi = Personnage.Tanky;

    // Start is called before the first frame update
    void Start()
    {
        GameObject joueur = GameObject.FindGameObjectWithTag(personnageChoisi.ToString());
        joueur.GetComponentInChildren<Camera>().enabled = true;
        joueur.GetComponent<CarUserControl>().enabled = true;
        joueur.GetComponent<CarAIControl>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}