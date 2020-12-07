using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class UIFinPartie : MonoBehaviour
{
    void Start()
    {
        InitUI();
    }

    private void InitUI()
    {
        List<KeyValuePair<Personnage, int>> points = GetListPointsOrdre();

        int cpt = 0;

        foreach(KeyValuePair<Personnage, int> item in points)
        {
            Sprite test = Resources.Load<Sprite>($"{item.Key}_tete");
            GameObject.FindGameObjectWithTag($"image_{cpt}").GetComponent<Image>().sprite = Resources.Load<Sprite>($"{item.Key}_tete");
            GameObject.FindGameObjectWithTag($"point_{cpt}").GetComponent<Text>().text = item.Value.ToString();
            cpt++;
        }
    }
}
