using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanktakedamage : MonoBehaviour {
    public Transform damagedtank;
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("CompleteShell")){
            this.gameObject.SetActive(false);
            Instantiate(damagedtank, this.transform.position, this.transform.rotation);

        }
    }

   
}
