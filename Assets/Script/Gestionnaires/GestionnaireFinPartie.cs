using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class GestionnaireFinPartie : MonoBehaviour
{
    private const int POINT_PREMIERE_PLACE = 300;
    private const int DIMINUTION_POINT_PAR_PLACE = 50;
    private static Dictionary<Personnage, bool> aFiniPersonnage;

    public void Start()
    {
        aFiniPersonnage = new Dictionary<Personnage, bool>();

        foreach (Personnage personnage in Enum.GetValues(typeof(Personnage)))
        {
            aFiniPersonnage.Add(personnage, false);
        }
    }

    public static void FiniCourse(Personnage personnage)
    {
        aFiniPersonnage[personnage] = true;
        AddPoints(personnage, POINT_PREMIERE_PLACE - (NbPersonnageFini() - 1) * DIMINUTION_POINT_PAR_PLACE);

        if(OntTousFini())
            SceneManager.LoadScene(2);
    }

    private static bool OntTousFini()
    {
        foreach(Personnage personnage in Enum.GetValues(typeof(Personnage)))
        {
            if (!aFiniPersonnage[personnage])
                return false;
        }

        return true;
    }

    private static int NbPersonnageFini() => aFiniPersonnage.Count(p => p.Value);
}
