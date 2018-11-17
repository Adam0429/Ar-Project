using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamage : MonoBehaviour {
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("CompleteShell")){
            this.gameObject.SetActive(false);
        }
    }

   
}
