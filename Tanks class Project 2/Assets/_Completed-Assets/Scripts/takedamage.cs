using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamage : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Rocks").SetActive(false);
        print(collision.transform.name);

    }
    //private void OnParticleCollision(GameObject other)
    //{
    //    print("2222");

    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    print("2222");

    //}
}
