using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicollider : MonoBehaviour
{
    GameObject firework;
    private void Start()
    {
        firework = GameObject.Find("firework");
        firework.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("CompleteShell")) 
            firework.SetActive(true);

    }


}
