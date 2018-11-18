using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWin : MonoBehaviour {
    private Material HighLightMat;                                         //实现闪烁高亮效果材质球
    public bool win = false;
    private void Update()
    {
        HighLightMat = HighLightMat = Resources.Load("_Completed-Assets/Prefabs/New Material") as Material;

    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("Heli"))
        {

            win = true;
            this.gameObject.GetComponent<Renderer>().material = HighLightMat;
        }
    }


}
