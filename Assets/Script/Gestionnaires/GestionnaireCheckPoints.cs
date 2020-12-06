using System;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;
using static GestionnaireFinPartie;

public class GestionnaireCheckPoints : MonoBehaviour
{
    private static Dictionary<Personnage, int> tourActuelPersonnages;
    private static Dictionary<Personnage, int> checkPointActuelPersonnages;
    private static Transform[] checkPointsStatic;
    private static int nbToursStatic;

    [SerializeField] private int nbTours = 3;
    [SerializeField] private Transform[] checkPoints;

    public void Awake()
    {
        checkPointsStatic = checkPoints;
        nbToursStatic = nbTours;
        tourActuelPersonnages = new Dictionary<Personnage, int>();
        checkPointActuelPersonnages = new Dictionary<Personnage, int>();

        foreach (Personnage personnage in Enum.GetValues(typeof(Personnage)))
        {
            tourActuelPersonnages.Add(personnage, 0);
            checkPointActuelPersonnages.Add(personnage, 0);
        }
    }

    public static void AccedeNouveauCheckPoints(Personnage personnage)
    {
        if (checkPointActuelPersonnages[personnage] + 1 >= checkPointsStatic.Length)
        {
            checkPointActuelPersonnages[personnage] = 0;
            return;
        }

        if (checkPointActuelPersonnages[personnage] == 0 &&
            tourActuelPersonnages[personnage]++ >= nbToursStatic)
            FiniCourse(personnage);

        checkPointActuelPersonnages[personnage]++;
    }

    public static bool EstCheckPointActuel(Personnage personnage, Transform transform)
        => checkPointsStatic[checkPointActuelPersonnages[personnage]] == transform;
}
