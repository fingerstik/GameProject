using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
     static public int ClearScore = 0;
     static public int Star = 0;
     // Start is called before the first frame update
     static public void SetRecord(int s)
     {
          ClearScore = s;
          SetStar();
     }

     static private void SetStar()
     {
          if (ClearScore < 100)
               Star = 0;
          else if (ClearScore < 150)
               Star = 1;
          else if (ClearScore < 200)
               Star = 2;
          else
               Star = 3;
     }
     static public int GetStar()
     {
          return Star;
     }
}
