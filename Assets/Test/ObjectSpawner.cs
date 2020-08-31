using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    private bool isObject = false;
    private GameObject obj;
    private float speed = 10f;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update()
    {
        if(!isObject && (Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            isObject = true;
        }
        else
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, placementIndicator.transform.position, speed * Time.deltaTime);
        }
    }
}
