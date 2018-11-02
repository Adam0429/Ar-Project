using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour {
    GameObject samuzai;
    GameObject soldier;
    Animator animator;
    float Distance;
    // Use this for initialization
    void Start () {
        samuzai = GameObject.Find("samuzai");
        //soldier = GameObject.Find("Soldier");
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = (this.transform.position - samuzai.transform.position).magnitude;
        Debug.Log(Distance);
        if(Distance<500){
            buttonshoot();
        }
        else{
            buttonrun();
        }
        //Debug.Log("samuzai:"+samuzai.transform.position);

        //Debug.Log(soldier.transform.position);
    }
    public void buttonshoot(){
        animator.SetTrigger("shoot");

    }
    public void buttonrun()
    {
        animator.SetTrigger("run");

    }
    public void buttonthrow()
    {
        animator.SetTrigger("throw");
    }

    public void buttondeath()
    {
        animator.SetTrigger("death");
    }
}
