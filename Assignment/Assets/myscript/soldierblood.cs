using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class soldierblood : MonoBehaviour
{
    //public Slider mSlider;//将前面创建的Slider拖到此处；  
    GameObject Slider;
    void Start()
    {
        //uiRoot = GameObject.FindGameObjectWithTag("UIRoot");
        //mSlider = this.GetComponentInChildren<Slider>();
        Slider = GameObject.Find("SoldierSlider");
        //if (!soldier.gameObject.activeSelf){
        //    Slider.SetActive(false);
        //}
    }

    void Update()
    {
        //if (!soldier.gameObject.activeSelf)
        //{
        //    Slider.SetActive(false);
        //}
        Slider.transform.rotation = Camera.main.transform.rotation;

        Vector3 pos0 = transform.position;
        Vector3 pos1 = Camera.main.WorldToScreenPoint(pos0);
        //将屏幕坐标转换为NGUI相机的世界坐标。  
        //mSlider.transform.position = UICamera.currentCamera.ScreenToWorldPoint(pos1) + new Vector3(-0.4f, 0.3f, 0);

        //改变血量  
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    mSlider.value = 50;
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    mSlider.value = 100;
        //}
    }
}