using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays_Lists : MonoBehaviour {

     string[] myFirstArray = { "Rock", "Star", "Pop", "Buzz" }; //First Way[Single Dimensional Array]
    // int[] myFirstArray = new int[5];//Second way[Single Dimensional Array]
    // int[,] mySecondDimensionalArray = new int[3, 3]; //Second Way[Double Dimensional Array]
    // int[,] mySecondDimensionalArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; //First Way[Double Dimensional Array]

    void Start ()
    {
       /*mySecondDimensionalArray[0, 0] = 0;  //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[0, 1] = 1;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[0, 2] =2;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[1, 0] = 10;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[1, 1] =11;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[1, 2] = 12;  //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[2, 0] = 20;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[2, 1] = 21;   //Second Way[Double Dimensional Array]
         mySecondDimensionalArray[2, 2] = 22;*/  //Second Way[Double Dimensional Array]

        // myFirstArray[0] = 10;//Second way[Single Dimensional Array]
        // myFirstArray[1] = 20;//Second way[Single Dimensional Array]
        // myFirstArray[2] = 30;//Second way[Single Dimensional Array]
        // myFirstArray[3] = 40;//Second way[Single Dimensional Array]
        // myFirstArray[4] = 50;//Second way[Single Dimensional Array]

        // int myintArray = Random.Range(0, myFirstArray.Length);        //First Way[Single Dimensional Array]
        // string myArray = myFirstArray[myintArray];                   //First Way[Single Dimensional Array]
        //int mySecondArray=mySecondDimensionalArray[0,2]
        Debug.Log(myFirstArray[3]); 
	}
	
	
	void Update ()
    {
		
	}
}
