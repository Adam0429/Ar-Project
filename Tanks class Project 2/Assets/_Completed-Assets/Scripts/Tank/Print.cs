using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour {
    GameObject game;
	// Use this for initialization
	void Start () {
        //game = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        print(this.transform.position);
	}
}
