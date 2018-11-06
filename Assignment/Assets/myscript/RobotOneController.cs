using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;


public class RobotOneController : MonoBehaviour
{
    public Transform Robot1;
    public Transform Robot2;
    //public Transform HPBar;
    //public Transform Shild;

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
        if (Robot1.gameObject.activeSelf&&Robot2.gameObject.activeSelf && RobotTwoController.life > 0)
        {
            //保持看着敌方机器人
            Quaternion rotation = Quaternion.LookRotation(Robot2.position - transform.position, transform.up);

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
                float distance = Vector3.Distance(transform.position, Robot2.position);
                if (distance < fireDistance)
                {
                    b_Attack = true;

                    AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                    print(info.normalizedTime);
                    if (info.normalizedTime > 1.33f && RobotOneController.life > 0)
                    {

                        RobotTwoController.life -= damage;
                    }

                }
                else
                {
                    b_Attack = false;
                }
            }

        }
        if (RobotTwoController.life<=0){
            animator.SetTrigger("run");
        }
        slider.value = life;
        if (life > 0)
        {
            animator.SetBool("shoot", b_Attack);
        }
        else{
            if(death)
            {
                animator.SetBool("death", death);
                death = !death;
            }
        }
    }


    void OnEnable()
    {
        life = 100;
        b_Attack = false;
        death = true;
        //transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //Shild.gameObject.SetActive(false);

    }
}


//public class SoldierController : MonoBehaviour {
//    GameObject samuzai;
//    GameObject soldier;
//    Animator animator;
//    float Distance;
//    Vector3 minus;
//    // Use this for initialization
//    void Start () {
//        samuzai = GameObject.Find("samuzai");
//        //soldier = GameObject.Find("Soldier");
//        animator = this.GetComponent<Animator>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //minus = this.transform.position - samuzai.transform.position;
//        //Distance = (this.transform.position - samuzai.transform.position).magnitude;
//        ////this.transform.SetPositionAndRotation(this.transform.localPosition, Quaternion.Euler(new Vector3(minus.x, 0, minus.z)));
//        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(samuzai.transform.position - transform.position), 1 * Time.deltaTime);
//        //if (Distance<300){
//            //print("1");
//        buttonshoot();
//            //print("2");
//        buttonreload();
//        //}
//        //如果我们勾选了该项，在动画转换时会等待当前动画播放完毕才会转换到下一个动画，如果当前动画是循环动画会等待本次播放完毕时转换，所以对于需要立即转换动画的情况时记得要取消勾选
//        //还有一种情况时，当我当前的动画播放完毕后就自动转换到箭头所指的下一个状态（没有其他跳转条件），此时必须勾选该选项，否则动画播放完毕后就会卡在最后一帧，如果是循环动画就会一直循环播放。
//        //else{
//        //    buttonrun();
//        //}
//    }

//    public void buttonshoot(){
//        animator.SetBool("shoot",true);

//    }
//    public void buttonrun()
//    {
//        animator.SetTrigger("run");

//    }
//    public void buttonthrow()
//    {
//        animator.SetTrigger("throw");
//    }
//    public void buttonreload()
//    {
//        animator.SetBool("reload",true);

//    }
//    public void buttondeath()
//    {
//        animator.SetTrigger("death");
//    }
//}
