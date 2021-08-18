using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreManager : MonoBehaviour
{
     public static int MyScore;
     public static int OtherScore;
     public Text MyText;
     public Text OtherText;
     // Start is called before the first frame update
     void Start()
     {
          MyScore = 0;
          OtherScore = 0;

     }

     // Update is called once per frame
     void Update()
     {
          MyText.text = "My Score : " + MyScore.ToString();
          OtherText.text = "Other Score : " + OtherScore.ToString();
     }
     public void AddScore()
     {
          MyScore += 10;
     }
     public int GetMyScore()
     {
          return MyScore;
     }
     public int GetOtherScore()
     {
          return OtherScore;
     }
}
