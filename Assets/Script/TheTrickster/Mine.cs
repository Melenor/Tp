using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class Mine : MonoBehaviour
{
    [SerializeField] private float forceExplosion = 300_000;
    [SerializeField] private float rayon = 100;
    [SerializeField] private float modificateur = 2;
    [SerializeField] private float rotation = 2_000;

    private void OnTriggerEnter(Collider other)
    {
        if (EstPersonnageNonImmunise(other.gameObject.tag))
        {
            other.gameObject.GetComponent<PersonnageTouchable>()
                .ToucheMine(forceExplosion, rayon, modificateur, new Vector3(rotation, rotation, rotation));
            AddPoints(Personnage.TheTrickster);
            Destroy(gameObject);
        }
    }
}
