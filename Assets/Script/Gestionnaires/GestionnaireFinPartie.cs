using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class GestionnaireFinPartie : MonoBehaviour
{
    private const int POINT_PREMIERE_PLACE = 300;
    private const int DIMINUTION_POINT_PAR_PLACE = 50;
    private static int conteurFini = 0;

    public static void FiniCourse(Personnage personnage)
    {
        AddPoints(personnage, POINT_PREMIERE_PLACE - conteurFini * DIMINUTION_POINT_PAR_PLACE);

        if(conteurFini++ >= Enum.GetValues(typeof(Personnage)).Length - 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}
