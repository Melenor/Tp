using UnityEngine;
using static GestionnairePersonnage;
using static GestionnairePoints;

public class Mine : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer mesh;
    private bool vaEtreDetruit = false;

    [SerializeField] private float forceExplosion = 300_000;
    [SerializeField] private float rayon = 100;
    [SerializeField] private float modificateur = 2;
    [SerializeField] private float rotation = 2_000;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!vaEtreDetruit && EstPersonnageNonImmunise(other.gameObject.tag))
        {
            vaEtreDetruit = true;
            // On cache la mine tout de suite pour donner l'impression qu'elle est détruite,
            // mais on laisse le temps à l'audio de jouer avant de détruire l'objet pour de vrai.
            mesh.enabled = false;
            audioSource.PlayOneShot(audioSource.clip);

            other.gameObject.GetComponent<PersonnageTouchable>()
                .ToucheMine(forceExplosion, rayon, modificateur, new Vector3(rotation, rotation, rotation));
            AddPoints(Personnage.TheTrickster);

            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
