using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fly : MonoBehaviour {
    GameObject Heli;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

    }
    void OnEnable(){
        EasyButton.On_ButtonDown += Fly;
        //EasyButton.On_ButtonUp += Down;
    }
	// Update is called once per frame
	void Update () {

        if (this.transform.localPosition.y > 0)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime );
        }
        else{
            animator.SetBool("Fly", false);

        }

    }
    void Fly(string buttonname){
        animator.SetBool("Fly", true);
        this.transform.Translate(Vector3.up * Time.deltaTime * 3f);
    }
    void Restart(){
        SceneManager.LoadScene(0);
    }

}
