using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RobotTwoController : MonoBehaviour
{


    public Transform Robot1;
    public Transform Robot2;

    Animator animator;

    public static float life;


    float fireDistance;
    float damage;
    float rotateSpeed;
    float stopRotation;
    Text text;

    bool b_Attack;

    bool b_Dead;
    Slider slider;

    //public GameObject HPObj;
    //public GameObject ExplosionBig;


    void Awake()
    {
        animator = GetComponent<Animator>();
        life = 100;
        fireDistance = 130;
        damage = 50;
        rotateSpeed = 0.8f;
        stopRotation = 3f;

        b_Attack = false;
        b_Dead = false;
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        slider = this.GetComponentInChildren<Slider>();
    }



    void FixedUpdate()
    {
        text.text = (RobotOneController.life).ToString();

        if (Robot1.gameObject.activeSelf&& Robot2.gameObject.activeSelf)
        {
            //保持看着敌方机器人
            Quaternion rotation = Quaternion.LookRotation(Robot1.position - transform.position, transform.up);

            //rotat差值
            Vector3 differ = transform.rotation.eulerAngles - rotation.eulerAngles;


            if (differ.magnitude > stopRotation)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Robot1.transform.position - transform.position), 1 * Time.deltaTime);

            }
            else
            {
                transform.rotation = rotation;

                ////计算是否在交火距离
                float distance = Vector3.Distance(transform.position, Robot1.position);

                if (distance < fireDistance)
                {
                    b_Attack = true;

                    AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

                    if (info.IsName("Attack") && info.normalizedTime > 0.9f && RobotOneController.life > 0)
                    {
                        RobotOneController.life -= damage;
                    }

                }

                else
                {
                    b_Attack = false;
                }
            }
        }
            
        if(RobotOneController.life<=0){
            b_Attack = false;
            b_Dead = true;
        }
        slider.value = life;


        //HPObj.GetComponent<MeshRenderer>().material.SetFloat("_Float", life);
        animator.SetBool("attack", b_Attack);
        animator.SetBool("jump", b_Dead);
        if(life<=0){
           animator.SetBool("die", true);
        }
    

    }

    void OnEnable()
    {
        life = 100;
        b_Attack = false;
        b_Dead = false;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        //ExplosionBig.SetActive(false);

    }
}
