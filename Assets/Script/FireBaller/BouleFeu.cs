using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class BouleFeu : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer mesh;
    private ParticleSystem particules;
    private bool vaEtreDetruit = false;

    [SerializeField] private float forceImpact = 1_000_000;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        particules = GetComponentInChildren<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!vaEtreDetruit)
        {
            vaEtreDetruit = true;

            if (EstPersonnageNonImmunise(collision.gameObject.tag))
            {
                AddPoints(Personnage.FireBaller);
                collision.gameObject.GetComponent<PersonnageTouchable>().ToucheFeu(-collision.impulse * forceImpact);
            }

            mesh.enabled = false;
            particules.Stop();
            particules.Clear();
            Destroy(gameObject, audioSource.isPlaying ? audioSource.clip.length : 0);
        }
    }
}
