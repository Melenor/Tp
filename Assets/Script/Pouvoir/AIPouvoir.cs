using UnityEngine;

[RequireComponent(typeof(Pouvoir))]
public class AIPouvoir : MonoBehaviour
{
    private Pouvoir pouvoir;


    void Awake()
    {
        pouvoir = GetComponent<Pouvoir>();
    }

    public void OnChampVisionTriggerEnter(Collider other)
    {
        if (GestionnairePersonnage.EstPersonnage(other.tag))
        {
            pouvoir.UtiliserPouvoir();
        }
    }
}
