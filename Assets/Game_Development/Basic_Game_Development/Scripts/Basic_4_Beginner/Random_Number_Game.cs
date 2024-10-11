using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Random_Number_Game
{
    public class Random_Number_Game : MonoBehaviour
    {
        float roundStartDelayTime = 3;
        float roundStartTime;
        int waitTime;
        [SerializeField]
        bool roundStarted;

        void Start()
        {
            print("Press the Spacebar once you think the alloted time is up");
            Invoke("SetNewRandomTime", roundStartDelayTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
            {
                InputRecived();
            }
        }

        void InputRecived()
        {


            float playerWaitTime = Time.time - roundStartTime;
            float error = Mathf.Abs(waitTime - playerWaitTime);

            Debug.Log("You waited for" + playerWaitTime + "Seconds. that's " + error + " seconds off. " + GenerateMessage(error));
            Invoke("SetNewRandomTime", roundStartDelayTime);
            roundStarted = false;
        }

        string GenerateMessage(float error)
        {
            string message = "";
            if (error < .15f)
            {
                message = "Oustanding!";
            }
            else if (error < .75f)
            {
                message = "Exceeds Expectations.";
            }
            else if (error < 1.25f)
            {
                message = "Acceptable.";
            }
            else if (error < 1.75f)
            {
                message = "Poor.";
            }
            else
            {
                message = "Dreadful.";
            }
            return message;
        }

        void SetNewRandomTime()
        {
            waitTime = Random.Range(5, 21);
            roundStartTime = Time.time;
            roundStarted = true;
            Debug.Log(waitTime + " Seconds.");
        }
    }
}

