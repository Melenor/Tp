using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChampVision : MonoBehaviour
{
    private AIPouvoir aIPouvoir;

    private void Start()
    {
        aIPouvoir = transform.parent.gameObject.GetComponent<AIPouvoir>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActiveAndEnabled)
        {
            aIPouvoir.OnChampVisionTriggerEnter(other);
        }
    }
}
