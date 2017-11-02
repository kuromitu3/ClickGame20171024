using UnityEngine;
using System.Collections;

public class IgaguriGenerator : MonoBehaviour
{

    public GameObject igaguriPrefab;

    void Update()
    {            igaguri.GetComponent<IgaguriController>().Shoot(
        if (Input.GetMouseButtonDown(0)){
            GameObject igaguri =
                Instantiate(igaguriPrefab) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

                worldDir.normalized * 2000);
        }
    }
}
