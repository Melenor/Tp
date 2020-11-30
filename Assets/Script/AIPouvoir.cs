using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Pouvoir))]
public class AIPouvoir : MonoBehaviour
{
    private Pouvoir pouvoir;
    private float cooldown = 0f;
    private float delaiTir = 2f;

    void Awake()
    {
        pouvoir = GetComponent<Pouvoir>();
    }

    public void OnChampVisionTriggerEnter(Collider other)
    {
        if (Time.time - cooldown > delaiTir && SelectionPersonnage.EstPersonnage(other.tag))
        {
            pouvoir.UtiliserPouvoir();
            cooldown = Time.time;
        }
    }
}
