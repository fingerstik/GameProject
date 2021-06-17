using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
     [Header("Player")]
     public PlayerController playerLogic;

     [Header("Count n TimeOver")]
     public GameObject CountNo1;
     public GameObject CountNo2;
     public GameObject CountNo3;
     public GameObject TimeOver;

     [Header("UI Info")]
     public TimeLeft timeLeft;
     public ScoreManager scManager;
     public ControlRecipe controlRecipe;
     private int[] Recipe;
     public Fade UIFade;

     [Header("Check")]
     public int chekcRecipe1;
     public int chekcRecipe2;
     public int chekcRecipe3;


     [Header("Scene")]
     public GameSceneManager gcManager;

     static STATE State;

     private bool check;
     private float StageTime;
     private int StageScore;
     private int Timer;

     enum STATE {START, STAGE, END}

     // Start is called before the first frame update
     void Start()
     {
          check = false;
          Timer = 0;
          StageTime = 0;
          State = STATE.START;
          CountNo1.SetActive(false);
          CountNo2.SetActive(false);
          CountNo3.SetActive(false);
          TimeOver.SetActive(false);
          Recipe = new int[3];

          for (int i = 0; i < 3; i++)
          {
               Recipe[i] = -1;
          }
     }

     // Update is called once per frame
     void Update()
     {
          chekcRecipe1 = Recipe[0];
          chekcRecipe2 = Recipe[1];
          chekcRecipe3 = Recipe[2];
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
          if (Timer == 0)
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
               //시작 출력
               else
               {
                    CountNo1.SetActive(false);
                    playerLogic.StopByStage = false;
                    State = STATE.STAGE;
                    Timer = 0;
                    MakeRecipe();
                    Time.timeScale = 1.0f; //게임시작
               }
          }
     }

     public void GameStage()
     {
          StageTime = timeLeft.GetTime();
          StageScore = scManager.GetScore();
          Timer++;
          if (Timer % 300 == 0)
          {
               MakeRecipe();
               Timer = 0;
          }

          if (StageTime == 0)
          {
               Timer = 0;
               playerLogic.StopByStage = true;
               State = STATE.END;
          }
     }
     public void EndStage()
     {
          if (Timer <= 90)
          {
               if (Timer >= 30 && !check)
               {
                    UIFade.StartFadeOut();
                    check = true;
               }
               Timer++;
               TimeOver.SetActive(true);
          }
          else
          {
               Invoke(null, 1);
               gcManager.GoEndScene();
          }
     }
     public void ResetRecipe(int idx)
     {
          Recipe[idx-1] = -1;
     }
     public int GetRecipe(int idx)
     {
          return Recipe[idx-1];
     }
     private void MakeRecipe() {
          if (Recipe[0] == -1)
          {
               Recipe[0] = Random.Range(1, 4);
               controlRecipe.OnRecipe(1, Recipe[0]);
               
          }
          else if (Recipe[1] == -1)
          {
               Recipe[1] = Random.Range(1, 4);
               controlRecipe.OnRecipe(2, Recipe[1]);
          }
          else if (Recipe[2] == -1)
          {
               Recipe[2] = Random.Range(1, 4);
               controlRecipe.OnRecipe(3, Recipe[2]);
          }
     }
}
