using UnityEngine;

public class AIPouvoir : MonoBehaviour
{
    private void Start()
    {
        // La méthode start est nécessaire pour pouvoir disable le script.
    }

    public void OnChampVisionTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
