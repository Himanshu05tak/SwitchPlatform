using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game_Development.Basic_Game_Development.Scripts.Endless
{
    public class GameOver_Manager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverScreen;
        [SerializeField]
        private Text secondsSurvivedUI;
        [SerializeField]
        private bool gameOver;

        void Start()
        {
            FindObjectOfType<Player_Controller>().OnPlayerDeath += OnGameOver;
        }

        void Update()
        {
            if (gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    SceneManager.LoadScene("Endless_Block");
                }
            }
        }
        public void OnGameOver()
        {
            gameOverScreen.SetActive(true);
            secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
            gameOver = true;
        }
    }
}

