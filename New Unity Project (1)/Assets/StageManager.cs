using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
     public PlayerController playerLogic;

     public GameObject CountNo1;
     public GameObject CountNo2;
     public GameObject CountNo3;

     static STATE State;

     private float StageTime;
     private int StageScore;
     private int Timer;

     enum STATE {START, STAGE, END}

     // Start is called before the first frame update
     void Start()
     {
          Timer = 0;
          StageTime = 0;
          State = STATE.START;
          CountNo1.SetActive(false);
          CountNo2.SetActive(false);
          CountNo3.SetActive(false);
     }

     // Update is called once per frame
     void Update()
     {
          //게임 시작시 정지
          
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
                    break;

          }
     }

     public void StartStage()
     {
          //게임 시작
          if(Timer == 0)
          {
               playerLogic.StopByStage = true;
               Time.timeScale = 0.0f;
          }
          //카운트
          if(Timer <= 180)
          {
               Timer++;
               //카운트 3
               if(Timer < 60)
               {
                    CountNo3.SetActive(true);
               }
               //카운트 2
               else if (Timer < 120)
               {
                    CountNo3.SetActive(false);
                    CountNo2.SetActive(true);
               }
               //카운트 1
               else if (Timer < 180)
               {
                    CountNo2.SetActive(false);
                    CountNo1.SetActive(true);
               }
               else
               //시작 출력
               {
                    CountNo1.SetActive(false);
                    playerLogic.StopByStage = false;
                    Time.timeScale = 1.0f; //게임시작
               }
          }
     }


     public void GameStage()
     {

     }
     public void EndStage()
     {

     }
}
