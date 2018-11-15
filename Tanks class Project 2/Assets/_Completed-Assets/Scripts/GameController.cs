using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Transform Heli;
    public Transform End;
    //public Transform HPBar;
    //public Transform Shild;
    public Text m_MessageText;
    Animator animator;

    public static float life;

    bool death;
    Slider slider;



    void Awake()
    {
        animator = GetComponent<Animator>();
        life = 100;
        slider = this.GetComponentInChildren<Slider>();
        StartCoroutine(RoundStarting());

    }



    void Update()
    {   
        if (Heli.gameObject.activeSelf && End.gameObject.activeSelf)
        {

            float distance = Vector3.Distance(transform.position, End.position);
            if(distance <15 && distance>0)//when object not render distance is 0
            {
                m_MessageText.text = "win";
            }
            else{
                m_MessageText.text = "moving";
            }

        }
    }

    private IEnumerator RoundStarting()
    {
        // As soon as the round starts reset the tanks and make sure they can't move.
        //ResetAllTanks ();
        //DisableTankControl ();
        m_MessageText.text = "start!";

        // Snap the camera's zoom and position to something appropriate for the reset tanks.
        //m_CameraControl.SetStartPositionAndSize ();

        // Increment the round number and display text showing the players what round it is.

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return new WaitForSeconds(3);
    }
}
