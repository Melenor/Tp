using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GestionnairePersonnage;

public class MainMenu : MonoBehaviour
{
    public void PlayIcerMan()
    {
        GestionnairePersonnage.personnageChoisi = Personnage.IcerMan;
        LoadMainScene();
    }
    public void PlayFireBaller()
    {
        GestionnairePersonnage.personnageChoisi = Personnage.FireBaller;
        LoadMainScene();
    }
    public void PlayTanky()
    {
        GestionnairePersonnage.personnageChoisi = Personnage.Tanky;
        LoadMainScene();
    }
    public void PlayTheTrickster()
    {
        GestionnairePersonnage.personnageChoisi = Personnage.TheTrickster;
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
