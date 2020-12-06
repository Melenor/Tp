using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetruireObjet : MonoBehaviour
{
    [SerializeField] private float tempsDestruction = 2f;

    // Update is called once per frame
    void Update()
    {
        if ((tempsDestruction -= Time.deltaTime) < 0)
            Destroy(gameObject);
    }
}
