using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public float dropSpeed = -0.03f;
	
	void Update () {
        transform.Translate(0, this.dropSpeed, 0);
        if (transform.position.y < -1.0f){
            Destroy(gameObject);
        }

	}
}
