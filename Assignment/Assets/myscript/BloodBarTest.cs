using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBarTest : MonoBehaviour {  
       
    public GUISkin theSkin;  
    public float bloodValue = 10.0f;  
       
    private float tmpValue;  
    private Rect rctBloodBar;  
    private Rect rctUpButton;  
    private Rect rctDownButton;  
    private bool onoff;  
   
    // Use this for initialization  
    void Start () {  
        rctBloodBar = new Rect (20,20,200,20);  
        rctUpButton = new Rect (50,40,40,20);  
        rctDownButton = new Rect (50,70,40,20);  
           
        tmpValue = bloodValue;  
    }  
       
       
    void OnGUI(){  
        GUI.skin = theSkin;  
           
        if (GUI.Button (rctUpButton,"加血")){  
            tmpValue += 1.0f;  
        }  
        if (GUI.Button (rctDownButton,"减血")){  
            tmpValue -= 1.0f;     
        }         
           
        //血值超过上限,不再增加  
        if (bloodValue > 10.0f) tmpValue = 10.0f;  
               
        //血值超过下限 ,归零  
        if (bloodValue < 0.0f) tmpValue = 0.0f;  
   
        //注解一：  
        //在Time.time时间内,从bloodValue渐变到tmpvalue值  
        //相当于把值tmpValue赋值给bloodValue  
        //bloodValue =tmpValue;  
        bloodValue = Mathf.Lerp(bloodValue,tmpValue,Time.time);  
           
        //拖动滚动条,第二个参数表示起始位置  
        GUI.HorizontalScrollbar(rctBloodBar,0.0f,bloodValue,0.0f,10.0f,GUI.skin.GetStyle("HorizontalScrollbar"));  
    }  
       
    // Update is called once per frame  
    void Update () {  
       
    }  
}