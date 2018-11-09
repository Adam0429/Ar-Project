using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;


public class TankController : MonoBehaviour
{
    public Transform Tank;
    public Transform End;
    //public Transform HPBar;
    //public Transform Shild;
    public Text m_MessageText;
    Animator animator;

    public static float life;

    float fireDistance;
    float damage;
    float rotateSpeed;
    float stopRotation;


    bool b_Attack;
    bool death;
    Slider slider;



    void Awake()
    {
        animator = GetComponent<Animator>();
        life = 100;
        fireDistance = 500;
        damage = 0.1f;
        rotateSpeed = 1.2f;
        stopRotation = 3f;
        b_Attack = false;
        slider = this.GetComponentInChildren<Slider>();

    }



    void Update()
    {
        if (Tank.gameObject.activeSelf && End.gameObject.activeSelf)
        {

            float distance = Vector3.Distance(transform.position, End.position);
            if(distance <15 && distance>0)//when object not render distance is 0
            {
                m_MessageText.text = "win";
            }
            else{
                m_MessageText.text = "moving";
            }

        }



    }
}
