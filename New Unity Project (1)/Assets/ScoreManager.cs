using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
     public static int score;
     private Text text;
     // Start is called before the first frame update
     void Start()
     {
          score = 0;
          text = GetComponent<Text>();
     }

     // Update is called once per frame
     void Update()
     {
          text.text = "Score : " + score.ToString();
     }
     public void AddScore()
     {
          score+=10;
     }
     public int GetScore()
     {
          return score;
     }
}
