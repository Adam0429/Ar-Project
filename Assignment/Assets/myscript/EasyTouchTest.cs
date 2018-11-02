
using UnityEngine;
using System.Collections;

public class EasyTouchTest : MonoBehaviour
{
    Animator animator;
    // Use this for initialization
    void Start()
    {
        //samuzai = GameObject.Find("samuzai");
        animator = this.GetComponent<Animator>();
    }
    //当摇杆可用时注册事件
    void OnEnable()
    {
        EasyJoystick.On_JoystickTouchUp+= OnJoystickMove;
        //EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }

    //当摇杆不可用时移除事件
    void OnDisable()
    {
        //EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    //当摇杆销毁时移除事件
    void OnDestroy()
    {
        //EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    //当摇杆处于停止状态时，角色进入待机状态
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        if (move.joystickName == "EasyJoystick")
        {
            animator.SetTrigger("crouch");
        }
    }

    //当摇杆处于移动状态时，角色开始奔跑
    void OnJoystickMove(MovingJoystick move)
    {
        Debug.Log("run");
        if (move.joystickName != "EasyJoystick")
        {
            return;
        }
        //获取摇杆偏移量
        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;
        if (joyPositionY != 0 || joyPositionX != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）
            transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            //移动玩家的位置（按朝向位置移动）
            transform.Translate(Vector3.forward * 10);
            //Debug.Log(transform.localPosition);
            //播放奔跑动画
            animator.SetTrigger("run");
        }
    }
}
