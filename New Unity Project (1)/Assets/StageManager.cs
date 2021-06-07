using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
     public string TxtMode;   // GUITEXT
     public string TxtStage;  // GUITEXT
     public string TxtTime;   // GUITEXT
     public string TxtTouch;  // GUITEXT
     public string TxtBonus;  // GUITEXT
     public string TxtScore;  // GUITEXT
     public string TxtMsg;    // GUITEXT
     
     static STATE State;

     private float StageTime;
     private int StageScore;

     enum STATE {START, STAGE, END}

     // Start is called before the first frame update
     void Start()
     {
          StageTime = 0;
          State = STATE.START;
     }

     // Update is called once per frame
     void Update()
     {
          switch (State)
          {
               case STATE.START:
                    StartStage();
                    break;
               case STATE.STAGE:
                    GameStage();
                    break;
               case STATE.END:
                    EndStage();

          }
     }

     public void StartStage()
     {

     }
     public void GameStage()
     {

     }
     public void EndStage()
     {

     }
}
