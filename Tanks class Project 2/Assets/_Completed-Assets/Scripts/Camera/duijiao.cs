using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class duijiao : MonoBehaviour {
    // Use this for initialization
    void Start () {
        GameObject ARCamera = GameObject.Find("ARCamera");
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

    }

    // Update is called once per frame
    void Update () {
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

    }
}
