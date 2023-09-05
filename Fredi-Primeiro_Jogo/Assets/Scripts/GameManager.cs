using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject hazardPrefab;

    void Start()
    {

        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {
        Instantiate(hazardPrefab, new Vector3(0, 11, 0), Quaternion.identity);

        yield return null;
    }
}
