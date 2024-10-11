using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Loops
{
    public class Loops : MonoBehaviour
    {
        /*  [SerializeField]
          private GameObject row1;
          [SerializeField]
          private GameObject coloum2;

          int[,] chess = new int[8, 8];


          public Loops(GameObject row,GameObject coloum)
          {
              row = row1;
              coloum = coloum2;
          }*/
        int[] powerOftwo = new int[20];

        void Start()
        {
            for (int i = 10; i < powerOftwo.Length; i++)
            {
                powerOftwo[i] = (int)Mathf.Pow(2, i);
                Debug.Log(powerOftwo[i]);
            }
        }

        void Update()
        {
           
           /* for (int row = 0; row < chess.GetLength(0); row++)
            {
                for (int colum = 0; colum < chess.GetLength(1); colum++)
                {
                    chess[row, colum] = (row + colum) % 2;
                    Debug.Log("Chess is " + chess[row, colum]); 
                }
            }*/
        }
    }
}
