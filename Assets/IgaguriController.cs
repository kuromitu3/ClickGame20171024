using UnityEngine;
using System.Collections;

public class IgaguriController : MonoBehaviour {


    GameObject target;
    public void Shoot(Vector3 dir) {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    
    void OnCollisionEnter(Collision other)
    {
        //GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<ParticleSystem>().Play();
        this.target = GameObject.Find("target");
        Destroy(target);
        this.target = GameObject.Find("target2");
        Destroy(target);
    }


    void Start () {
       
        Shoot(new Vector3(0, 200, 2000));
    }
}
