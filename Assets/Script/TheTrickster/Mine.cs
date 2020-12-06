using UnityEngine;
using static GestionnairePersonnage;

public class Mine : MonoBehaviour
{
    [SerializeField] private float forceExplosion = 500_000;
    [SerializeField] private float rayon = 100;
    [SerializeField] private float modificateur = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (EstPersonnageNonImmunise(other.gameObject.tag))
        {
            other.gameObject.GetComponent<PersonnageTouchable>().ToucheMine(forceExplosion, rayon, modificateur);
            Destroy(gameObject);
        }
    }
}
