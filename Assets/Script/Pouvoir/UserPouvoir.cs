using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Pouvoir))]
public class UserPouvoir : MonoBehaviour
{
    private Pouvoir pouvoir;

    void Awake()
    {
        pouvoir = GetComponent<Pouvoir>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            pouvoir.UtiliserPouvoir();
        }
    }
}
