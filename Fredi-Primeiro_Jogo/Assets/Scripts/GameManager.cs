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

        var x = Random.Range(-7, 7);
        var drag = Random.Range(0f, 2f);

        var hazard =  Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
        hazard.GetComponent<Rigidbody>().drag = drag;

        yield return new WaitForSeconds (1f);

        yield return SpawnHazards();
    }
}
