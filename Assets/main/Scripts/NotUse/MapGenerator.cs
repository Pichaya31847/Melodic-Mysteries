using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;

    private void Start()
    {
        {
            GameObject go = Instantiate(platformPrefab, new Vector3(7, 2, 0), Quaternion.identity);
            GameObject go1 = Instantiate(platformPrefab, new Vector3(1, 6, 0), Quaternion.identity);
            GameObject go2 = Instantiate(platformPrefab, new Vector3(1, 0, 0), Quaternion.identity);
        }
    }

}
