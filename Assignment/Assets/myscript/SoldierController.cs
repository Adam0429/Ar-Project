using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SoldierController : MonoBehaviour {
    GameObject samuzai;
    GameObject soldier;
    Animator animator;
    float Distance;
    Vector3 minus;
    // Use this for initialization
    void Start () {
        samuzai = GameObject.Find("samuzai");
        //soldier = GameObject.Find("Soldier");
        animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        minus = this.transform.position - samuzai.transform.position;
        Distance = (this.transform.position - samuzai.transform.position).magnitude;
        //this.transform.SetPositionAndRotation(this.transform.localPosition, Quaternion.Euler(new Vector3(minus.x, 0, minus.z)));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(samuzai.transform.position - transform.position), 1 * Time.deltaTime);
        if (Distance<300){
            buttonshoot();
            //buttonreload();
        }
        else{
            buttonrun();
        }
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
    public void buttonreload()
    {
        animator.SetTrigger("reload");
    }
    public void buttondeath()
    {
        animator.SetTrigger("death");
    }
}
