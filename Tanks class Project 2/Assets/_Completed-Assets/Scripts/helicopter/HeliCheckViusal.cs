using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCheckViusal : MonoBehaviour
{
    public bool visual = false;
    private void Start()
    {
    }
    private void Update()
    {
        check();
    }


    public void check()

    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        Collider[] colliderComponents = GetComponentsInChildren<Collider>();



        foreach (Renderer component in rendererComponents)

        {
            if(component.enabled){
                visual = true;
            }
            else{
                visual = false;

            }
        }




        //foreach (Collider component in colliderComponents)

        //{
        //    print(component.enabled);


        //}



    }
}
