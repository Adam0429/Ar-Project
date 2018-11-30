using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankShooting : MonoBehaviour
    {
        public Rigidbody m_Shell;                   
        public Transform m_FireTransform;           
        public Transform Heli;
        public Transform tank;

        public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
        public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
        public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
        public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.
        public float m_MaxLaunchForce = 30f;        // The force given to the shell if the fire button is held for the max charge time.
        public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.


        private string m_FireButton;                // The input axis that is used for launching shells.
        private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
        private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
        private int count = 1;
        bool helivisual = false;
        bool tankvisual = false;

        private void OnEnable()
        {
            // When the tank is turned on, reset the launch force and the UI
            m_CurrentLaunchForce = m_MinLaunchForce;
            m_AimSlider.value = m_MinLaunchForce;
        }


        private void Start()
        {
            m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        }


        private void Update ()
        {
            helivisual = GameObject.Find("Heli1").GetComponent<HeliCheckVisual>().visual;
            tankvisual = GameObject.Find("CompleteTank").GetComponent<TankCheckVisual>().visual;

            if (helivisual && tankvisual)
            {

                Quaternion rotation = Quaternion.LookRotation(Heli.position - transform.position, transform.up);

                Vector3 differ = transform.rotation.eulerAngles - rotation.eulerAngles;

                if (differ.magnitude > 3f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1.2f);
                }
                else
                {
                    transform.rotation = rotation;
                    count++;
                    if (count % 10 == 1)
                    {
                        //if (helivisual&&tankvisual)
                        {
                            Fire();
                        }
                    }
                }
            }
        }


        private void Fire ()
        {


            Rigidbody shellInstance =
                Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play ();
            m_CurrentLaunchForce = m_MinLaunchForce;

        }
    }
}