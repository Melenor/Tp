using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GestionnairePersonnage;

public class GestionnairePoints : MonoBehaviour
{
    static Dictionary<Personnage, int> pointsPersonnages;

    public void Start()
    {
        pointsPersonnages = new Dictionary<Personnage, int>();

        foreach (Personnage personnage in Enum.GetValues(typeof(Personnage)))
        {
            pointsPersonnages.Add(personnage, 0);
            UpdateUIPointage(personnage);
        }
    }

    public static void AddPoints(Personnage personnage, int nbPoints = 1)
    {
        pointsPersonnages[personnage] += nbPoints;

        UpdateUIPointage(personnage);
    }

    private static void UpdateUIPointage(Personnage personnage)
    {
        GameObject.FindGameObjectWithTag($"{personnage}TextPoint")
            .GetComponent<Text>().text = $"{personnage}: {pointsPersonnages[personnage]}";
    }
}
