using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulleFeu : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (SelectionPersonnage.EstPersonnage(collision.gameObject.tag))
        {
            Debug.Log("Collision avec un joueur.");
        }
        Destroy(this);
    }
}
