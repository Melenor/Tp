using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class RayonGlacePouvoir : MonoBehaviour, Pouvoir
{
    [SerializeField] private float portee = 10f;
    [SerializeField] private float dureeGlace = 12f;
    [SerializeField] private Transform positionCannon = default;
    [SerializeField] private LineRenderer rayonGlace;
    private float cooldown = 0f;
    private float delaiTir = 2f;

    public void UtiliserPouvoir()
    {
        if (Time.time - cooldown > delaiTir)
        {
            LineRenderer copieRayon = Instantiate(rayonGlace);
            copieRayon.SetPosition(0, positionCannon.position);

            RaycastHit infoRaycast;
            bool touche = Physics.Raycast(positionCannon.transform.position, positionCannon.transform.forward, out infoRaycast, portee);
            if (touche && EstPersonnageNonImmunise(infoRaycast.transform.tag))
            {
                AddPoints(Personnage.IcerMan);
                infoRaycast.transform.gameObject.GetComponent<PersonnageTouchable>().ToucheGlace(dureeGlace);
                copieRayon.SetPosition(1, infoRaycast.transform.position);
            }
            else
            {
                copieRayon.SetPosition(1, positionCannon.position + positionCannon.forward * portee);
            }
            cooldown = Time.time;
        }
    }
}
