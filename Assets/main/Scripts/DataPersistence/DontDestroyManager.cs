using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
    private static DontDestroyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
