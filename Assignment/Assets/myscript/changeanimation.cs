﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeanimation : MonoBehaviour {
    public GameObject samuzai;
    Animator animator;
    // Use this for initialization
    void Start () {
        samuzai = GameObject.Find("samuzai");
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void buttonattach(){
        animator.SetTrigger("attach");      
    }

    public void buttonrun()
    {
        animator.SetTrigger("run");
    }
}
