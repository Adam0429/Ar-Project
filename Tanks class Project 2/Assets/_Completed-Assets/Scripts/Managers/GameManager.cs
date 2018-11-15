using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Complete
{
    public class GameManager : MonoBehaviour
    {
        public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
        public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
        public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.
        public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.
        public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
        public GameObject m_TankPrefab;             // Reference to the prefab the players will control.
        public TankManager[] m_Tanks;               // A collection of managers for enabling and disabling different aspects of the tanks.

        
        private int m_RoundNumber;                  // Which round the game is currently on.
        private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
        private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.
        private bool m_RoundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
        private TankManager m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.


        public Transform Heli;
        public Transform End;
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
        private void Start()
        {
            animator = GetComponent<Animator>();
            life = 100;
            fireDistance = 500;
            damage = 0.1f;
            rotateSpeed = 1.2f;
            stopRotation = 3f;
            b_Attack = false;
            slider = this.GetComponentInChildren<Slider>();
            // Create the delays so they only have to be made once.
            //m_StartWait = new WaitForSeconds (m_StartDelay);
            //m_EndWait = new WaitForSeconds (m_EndDelay);

            ////SpawnAllTanks();
            ////SetCameraTargets();

            //// Once the tanks have been created and the camera is using them as targets, start the game.
            StartCoroutine (GameLoop ());
            //SceneManager.LoadScene(0);

        }


        private void SpawnAllTanks()
        {
            // For all the tanks...
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                // ... create them, set their player number and references needed for control.
                m_Tanks[i].m_Instance =
                    Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
                //m_Tanks[i].m_Instance.transform.localScale = new Vector3(10,10,10);
                m_Tanks[i].m_PlayerNumber = i + 1;
                m_Tanks[i].Setup();
            }
        }


        private void SetCameraTargets()
        {
            // Create a collection of transforms the same size as the number of tanks.
            Transform[] targets = new Transform[m_Tanks.Length];

            // For each of these transforms...
            for (int i = 0; i < targets.Length; i++)
            {
                // ... set it to the appropriate tank transform.
                targets[i] = m_Tanks[i].m_Instance.transform;
            }

            // These are the targets the camera should follow.
            m_CameraControl.m_Targets = targets;
        }

        // This function is to find out if there is a winner of the round.
        // This function is called with the assumption that 1 or fewer tanks are currently active.
        private bool GetWin()
        {

            if (Heli.gameObject.activeSelf && End.gameObject.activeSelf)
            {

                float distance = Vector3.Distance(Heli.position, End.position);
                m_MessageText.text = distance.ToString();
                if (distance < 10 && distance > 0)//when object not render distance is 0
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            return false;
            // If none of the tanks are active it is a draw so return null.
        }





        // This is called from start and will run each phase of the game one after another.
        private IEnumerator GameLoop ()
        {
            // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
            yield return StartCoroutine (RoundStarting ());
            // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
            yield return StartCoroutine (RoundPlaying());
            // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
            yield return StartCoroutine (RoundEnding());

            // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
            if (GetWin())
            {
                // If there is a game winner, restart the level.
                SceneManager.LoadScene(0);
            }
            //else
            //{
            //    // If there isn't a winner yet, restart this coroutine so the loop continues.
            //    // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            //    StartCoroutine (GameLoop ());
            //}
        }


        private IEnumerator RoundStarting ()
        {
            // As soon as the round starts reset the tanks and make sure they can't move.
            //ResetAllTanks ();
            //DisableTankControl ();

            // Snap the camera's zoom and position to something appropriate for the reset tanks.
            //m_CameraControl.SetStartPositionAndSize ();

            // Increment the round number and display text showing the players what round it is.
            m_MessageText.text = "Start ";

            // Wait for the specified length of time until yielding control back to the game loop.
            yield return new WaitForSeconds(3);
        }


        private IEnumerator RoundPlaying ()
        {
            // As soon as the round begins playing let the players control the tanks.
            //EnableTankControl ();

            // Clear the text from the screen.
            //m_MessageText.text = string.Empty;

            // While there is not one tank left...

            while(!GetWin())
            {
                // ... return on the next frame.
                yield return null;
            }
        }


        private IEnumerator RoundEnding ()
        {
            // Stop tanks from moving.
            //DisableTankControl ();

            // Clear the winner from the previous round.

            // Get a message based on the scores and whether or not there is a game winner and display it.
            m_MessageText.text = "YOU WIN!\n PREPARE FOR NEXT GAME";

            // Wait for the specified length of time until yielding control back to the game loop.
            yield return new WaitForSeconds(3);
        }




        // This function is used to turn all the tanks back on and reset their positions and properties.



        private void EnableTankControl()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].EnableControl();
            }
        }


        private void DisableTankControl()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].DisableControl();
            }
        }
    }
}