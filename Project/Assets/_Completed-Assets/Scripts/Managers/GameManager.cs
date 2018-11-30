using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Complete
{
    public class GameManager : MonoBehaviour
    {
        public float m_StartDelay = 3f;             
        public float m_EndDelay = 3f;               
        public Text m_MessageText;                  




        public Transform Heli;
        public Transform End;
        public Transform FireWork;

        Animator animator;
        GameObject HeliObject;
        GameObject EndObject;
        public static float life;

       
        Slider slider;
        private void Start()
        {

            slider = this.GetComponentInChildren<Slider>();
            // Create the delays so they only have to be made once.
            //m_StartWait = new WaitForSeconds (m_StartDelay);
            //m_EndWait = new WaitForSeconds (m_EndDelay);
            HeliObject = GameObject.Find("Heli1");
            EndObject = GameObject.Find("Helipad");
            ////SpawnAllTanks();
            ////SetCameraTargets();

            //// Once the tanks have been created and the camera is using them as targets, start the game.
            StartCoroutine(GameLoop());
            //SceneManager.LoadScene(0);


        }

        public void Update()
        {
            //Renderer[] rendercompent = GetComponentsInChildren<Renderer>();
            //foreach (Renderer compent in rendercompent)
            //{
            //    print("名字："+compent.name);
            //}
        }
        // This function is to find out if there is a winner of the round.
        // This function is called with the assumption that 1 or fewer tanks are currently active.
        private bool GetWin()
        {

            if (Heli.gameObject.activeSelf && End.gameObject.activeSelf)
            {

                float distance = Vector2.Distance(new Vector2(Heli.position.x,Heli.position.z),new Vector2(End.position.x,End.position.y));
                m_MessageText.text = "Fighting!!!";
                //(Heli.GetComponent<MeshFilter>().mesh.bounds.size.x *
                //distance.ToString();
                if (EndObject.GetComponent<GetWin>().win)//when object not render distance is 0
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            return false;
        }





        private IEnumerator GameLoop ()
        {
            yield return StartCoroutine (RoundPlaying());
            yield return StartCoroutine (RoundEnding());

            // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
            //if (GetWin())
            //{
            //    // If there is a game winner, restart the level.

            //    SceneManager.LoadScene(0);
            //GameObject Heli1 = GameObject.Find("Heli1");
            //Heli1.AddComponent<MoveController>();
            //本来想一局一局的游戏的，结果重新加载scence的时候，报错脚本被销毁
            //}
            //else
            //{
            //    // If there isn't a winner yet, restart this coroutine so the loop continues.
            //    // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            //    StartCoroutine (GameLoop ());
            //}
        }


        private IEnumerator RoundStarting ()
        {
             m_MessageText.text = "Start ";

            yield return new WaitForSeconds(3);
        }


        private IEnumerator RoundPlaying ()
        {
              while(!GetWin())
            {
                // ... return on the next frame.
                yield return null;
            }
        }


        private IEnumerator RoundEnding ()
        {
                
            m_MessageText.text = "YOU WIN!\n";
            //Instantiate(Heli, EndObject.transform.position, EndObject.transform.rotation);
            Heli.transform.position = EndObject.transform.position;
            Instantiate(FireWork, EndObject.transform.position, EndObject.transform.rotation);
            yield return new WaitForSeconds(100);
        }


    }
}