using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class GestionnaireFinPartie : MonoBehaviour
{
    private static int conteurFini = 0;

    public static void FiniCourse(Personnage personnage)
    {
        AddPoints(personnage, 300 - conteurFini * 50);
        Debug.Log($"{personnage} a fini la course avec {GetPoints(personnage)}");

        if(conteurFini++ >= Enum.GetValues(typeof(Personnage)).Length - 1)
        {
            Debug.Log("PARTIE TERMINÉE");
        }
    }
}
