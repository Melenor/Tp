using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class BouleFeu : MonoBehaviour
{
    [SerializeField] private float forceImpact = 1_000_000;
    private void OnCollisionEnter(Collision collision)
    {
        if (EstPersonnageNonImmunise(collision.gameObject.tag))
        {
            AddPoints(Personnage.FireBaller);
            collision.gameObject.GetComponent<PersonnageTouchable>().ToucheFeu(-collision.impulse * forceImpact);
        }
        Destroy(gameObject);
    }
}
