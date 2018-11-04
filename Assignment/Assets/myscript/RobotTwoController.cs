using UnityEngine;
using System.Collections;

public class RobotTwoController : MonoBehaviour
{


    public Transform Robot1;

    //  public  Transform Shild;

    Animator animator;

    public static float life;

    float fireDistance;
    float damage;
    float rotateSpeed;
    float stopRotation;


    bool b_Attack;

    bool b_Dead;

    //public GameObject HPObj;
    public GameObject LeftWeapon, RightWeapon;
    //public GameObject ExplosionBig;


    void Awake()
    {
        animator = GetComponent<Animator>();
        life = 100;
        fireDistance = 13;
        damage = 0.4f;
        rotateSpeed = 0.8f;
        stopRotation = 3f;

        b_Attack = false;
        b_Dead = false;
    }



    void Update()
    {
        if (life > 0)
        {

            if (Robot1.gameObject.activeInHierarchy)
            {
                //保持看着敌方机器人
                Quaternion rotation = Quaternion.LookRotation(Robot1.position - transform.position, transform.up);

                //rotat差值
                Vector3 differ = transform.rotation.eulerAngles - rotation.eulerAngles;


                if (differ.magnitude > stopRotation)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
                }
                else
                {
                    transform.rotation = rotation;

                    //计算是否在交火距离
                    float distance = Vector3.Distance(transform.position, Robot1.position);

                    if (distance < fireDistance)
                    {
                        b_Attack = true;
                        LeftWeapon.SetActive(true);
                        RightWeapon.SetActive(true);
                        //对敌方造成伤害
                        if (RobotOneController.life > 30)
                        {
                            RobotOneController.life -= damage;
                        }

                    }
                    else
                    {
                        b_Attack = false;
                        LeftWeapon.SetActive(false);
                        RightWeapon.SetActive(false);
                    }
                }
            }
            else
            {
                b_Attack = false;
                b_Dead = false;
                LeftWeapon.SetActive(false);
                RightWeapon.SetActive(false);
            }
        }
        else
        {
            //死亡
            life = 0;
            b_Attack = false;
            b_Dead = true;
            LeftWeapon.SetActive(false);
            RightWeapon.SetActive(false);
            //ExplosionBig.SetActive(true);

        }

        //HPObj.GetComponent<MeshRenderer>().material.SetFloat("_Float", life);
        animator.SetBool("attack", b_Attack);
        animator.SetBool("jump", b_Dead);
    }

    void OnEnable()
    {
        life = 100;
        b_Attack = false;
        b_Dead = false;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        LeftWeapon.SetActive(false);
        RightWeapon.SetActive(false);
        //ExplosionBig.SetActive(false);

    }
}
