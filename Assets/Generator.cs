using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public GameObject Prefab;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject tame =
                Instantiate(Prefab) as GameObject;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            Prefab.GetComponent<Controller>().Shoot(
             worldDir.normalized * 2000);
        }
	}
}
