using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using static GestionnairePersonnage;
using static GestionnairePoints;
using TMPro;

public class GestionnaireFinPartie : MonoBehaviour
{
    private const int SCENE_FIN = 2;
    private const int POINT_PREMIERE_PLACE = 300;
    private const int DIMINUTION_POINT_PAR_PLACE = 50;
    private static Dictionary<Personnage, bool> aFiniPersonnage;
    private static float? marqueurTemps = null;
    private static TextMeshProUGUI tempsRestant;
    private static float delaiFin = 20f;

    public void Start()
    {
        tempsRestant = GameObject.FindGameObjectWithTag("TempsRestant").GetComponent<TextMeshProUGUI>();
        aFiniPersonnage = new Dictionary<Personnage, bool>();

        foreach (Personnage personnage in Enum.GetValues(typeof(Personnage)))
            aFiniPersonnage.Add(personnage, false);
    }

    private void Update()
    {
        if (marqueurTemps.HasValue)
        {
            if (Time.time - marqueurTemps > delaiFin)
                SceneManager.LoadScene(SCENE_FIN);
            else
                UpdateUITempsRestant();
        }
    }

    public static void FiniCourse(Personnage personnage)
    {
        marqueurTemps = Time.time;
        aFiniPersonnage[personnage] = true;
        AddPoints(personnage, POINT_PREMIERE_PLACE - (NbPersonnageFini() - 1) * DIMINUTION_POINT_PAR_PLACE);
        UpdateUITempsRestant();

        if (OntTousFini())
            SceneManager.LoadScene(SCENE_FIN);
    }

    private static bool OntTousFini()
    {
        foreach (Personnage personnage in Enum.GetValues(typeof(Personnage)))
        {
            if (!aFiniPersonnage[personnage])
                return false;
        }

        return true;
    }

    private static void UpdateUITempsRestant()
    {
        if (marqueurTemps.HasValue)
        {
            string temps = (delaiFin - Math.Abs(marqueurTemps.Value - Time.time)).ToString("0.#");
            tempsRestant.text = temps.Contains(',') ? temps : $"{temps},0";
        }
    }

    private static int NbPersonnageFini() => aFiniPersonnage.Count(p => p.Value);
}
