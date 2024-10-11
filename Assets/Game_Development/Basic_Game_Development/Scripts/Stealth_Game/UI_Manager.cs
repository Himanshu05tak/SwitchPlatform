using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Development.Basic_Game_Development.Scripts.Stealth_Game
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameWinUI;
        [SerializeField]
        private GameObject gameLossUI;
        [SerializeField]
        private bool gameIsOver;

        void Start()
        {
            Guard.OnGuardHasSpottedPlayer += GameLossUI;
            Player_Contoller.OnReachedEndOfLevel += GameWinUI;
        }

        private void Update()
        {
            if (gameIsOver)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        void GameWinUI()
        {
            OnGameOver(gameWinUI);
        }

        void GameLossUI()
        {
            OnGameOver(gameLossUI);
        }

        void OnGameOver(GameObject gameOverUI)
        {
            gameOverUI.SetActive(true);
            gameIsOver = true;
            Guard.OnGuardHasSpottedPlayer -= GameLossUI;
            Player_Contoller.OnReachedEndOfLevel -= GameWinUI;

        }
    }
}
