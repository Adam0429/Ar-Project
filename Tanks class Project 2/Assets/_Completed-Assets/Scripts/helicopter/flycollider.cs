using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flycollider : MonoBehaviour
{
    GameObject firework;
    private void Start()
    {
        firework = GameObject.Find("firework");
        firework.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        firework.SetActive(true);

    }


}
