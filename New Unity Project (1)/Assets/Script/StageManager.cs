using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StageManager : MonoBehaviourPunCallbacks, IPunObservable
{

     [Header("Player")]
     public GameObject Player;
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

     [Header("Other")]
     public PhotonView PV;
     public Animator OtherPlayerAnim;
     public Text OtherPlayerText;
     private int OtherPlayerClearScore;

     static STATE State;
     
     private int StageScore;
     private int StageTime;
     public float Timer;

     enum STATE { START, STAGE, END }

     // Start is called before the first frame update
     void Start()
     {
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

          PV = GetComponent<PhotonView>();
          StartCoroutine(StartStage());
     }

     // Update is called once per frame
     void Update()
     {
          //게임 시작시 정지

          switch (State)
          {
               case STATE.START:
                    break;
               case STATE.STAGE:
                    GameStage();
                    break;
               case STATE.END:
                    break;

          }
     }

     public void GameStage()
     {
          StageTime = timeLeft.GetTime();
          StageScore = scManager.GetMyScore();
          PV.RPC("UpdateOtherPlayerScore", RpcTarget.Others, StageScore);

          Timer += Time.deltaTime;
          if (Timer >= 5)
          {
               MakeRecipe();
               Timer = 0;
          }

          if (StageTime == 0)
          {
               timeLeft.IsStop = true;
               StartCoroutine(EndStage());
          }
     }
     public void ResetRecipe(int idx)
     {
          Recipe[idx - 1] = -1;
     }
     public int GetRecipe(int idx)
     {
          return Recipe[idx - 1];
     }
     private void MakeRecipe()
     {
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

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
     {
          if(stream.IsWriting)
          {
               Debug.Log(StageScore);
               stream.SendNext(StageScore);
          }
          else
          {
               this.OtherPlayerClearScore = (int)stream.ReceiveNext();
          }
     }
     [PunRPC]
     void UpdateOtherPlayerScore(int Score)
     {
          StartCoroutine(OtherPlayerScore(Score));
     }

     IEnumerator StartStage()
     {
          UIFade.StartFadeIn();
          timeLeft.IsStop = true;
          yield return new WaitForSeconds(UIFade.FadeInTime);

          StartCoroutine(CountDown());
          yield return new WaitForSeconds(3.0f);
          timeLeft.IsStop = false;
          State = STATE.STAGE;
          MakeRecipe();
     }

     IEnumerator CountDown()
     {
          CountNo3.SetActive(true);
          yield return new WaitForSeconds(1.0f);

          CountNo3.SetActive(false);
          CountNo2.SetActive(true);
          yield return new WaitForSeconds(1.0f);

          CountNo2.SetActive(false);
          CountNo1.SetActive(true);
          yield return new WaitForSeconds(1.0f);

          CountNo1.SetActive(false);
     }

     IEnumerator EndStage()
     {
          TimeOver.SetActive(true);
          yield return new WaitForSeconds(0.5f);
          playerLogic.StopByStage = true;
          UIFade.StartFadeOut();
          yield return new WaitForSeconds(UIFade.FadeOutTime);
          StartCoroutine(LoadScene("EndScene"));
     }

     IEnumerator LoadScene(string sceneName)
     {
          GameResult.SetMyRecord(StageScore);
          GameResult.SetOtherRecord(OtherPlayerClearScore);

          AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
          while (!asyncOper.isDone)
          {
               yield return null;
          }
     }

     IEnumerator OtherPlayerScore(int Score)
     {
          OtherPlayerClearScore = Score;
          ScoreManager.OtherScore = Score;
          yield return null;
     }
}
