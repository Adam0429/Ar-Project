using UnityEngine;
using HedgehogTeam.EasyTouch;//引用命名空间



/// <summary>
/// Easy5 版本的基本写法
/// </summary>
public class MoveController : MonoBehaviour
{


    /// <summary>
    /// 更新函数
    /// </summary>
    void Update()
    {
        //用 EasyTouch.current 记录玩家输入的手势 presentGesture
        Gesture presentGesture = EasyTouch.current;

        //容错 （当玩家没有手势输入的时候）
        if (presentGesture != null)
        {

            //Debug.Log("用户：" + presentGesture.type);
            //以下判断 玩家手势类型 是否和 EasyTouch系统手势类型相同
            if (EasyTouch.EvtType.On_TouchStart == presentGesture.type)
            {
                Debug.Log("4");
                OnTouchStart(presentGesture);
            }
            else if (EasyTouch.EvtType.On_TouchUp == presentGesture.type)
            {
                Debug.Log("5");
                OnTouchEnd(presentGesture);
            }
            else if (EasyTouch.EvtType.On_Swipe == presentGesture.type)
            {
                Debug.Log("6");
                OnTouchSwipe(presentGesture);
            }
        }
    }



    /// <summary>
    /// 开始手势
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchStart(Gesture gesture)
    {
        print("OnTouchStart");
        print(gesture.startPosition + "开始坐标");
    }



    /// <summary>
    /// 结束手势
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchEnd(Gesture gesture)
    {
        print("OnTouchEnd");
        print(gesture.position + "结束坐标");
        print(gesture.actionTime + "结束持续了多久");
    }



    /// <summary>
    /// 拖动手势
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchSwipe(Gesture gesture)
    {
        print("OnTouchSwipe");
        print(gesture.position + "拖动坐标");
        print(gesture.actionTime + "拖动持续了多久");
        print(gesture.swipe + "类型");
    }
}
