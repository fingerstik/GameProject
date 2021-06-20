using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
     private static GameResult GR;

     static public int MyClearScore = 0;
     static public int MyStar = 0;

     static public int OtherClearScore = 0;
     static public int OtherStar = 0;

     public void Start()
     {
          if (GR == null)
          {
               GR = this;
               DontDestroyOnLoad(this.gameObject);
          }
          else
          {
               Destroy(this.gameObject);
          }
     }

     static public void SetMyRecord(int s)
     {
          MyClearScore = s;
          SetMyStar();
     }
     static public void SetOtherRecord(int s)
     {
          OtherClearScore = s;
          SetOtherStar();
     }

     static private void SetMyStar()
     {
          if (MyClearScore < 100)
               MyStar = 0;
          else if (MyClearScore < 150)
               MyStar = 1;
          else if (MyClearScore < 200)
               MyStar = 2;
          else
               MyStar = 3;
     }
     static private void SetOtherStar()
     {
          if (OtherClearScore < 100)
               OtherStar = 0;
          else if (OtherClearScore < 150)
               OtherStar = 1;
          else if (OtherClearScore < 200)
               OtherStar = 2;
          else
               OtherStar = 3;
     }

     static public string GetWinner()
     {
          string winner;

          if(MyClearScore > OtherClearScore)
          {
               winner = "WIN";
          }
          else if (MyClearScore < OtherClearScore)
          {
               winner = "LOSE";
          }
          else
          {
               winner = "DRAW";
          }

          return winner;
     }
}
