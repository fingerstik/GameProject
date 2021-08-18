using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
     public Fade UIFade;
     private float Timer;
     public PhotonManager phManager;
     public Text WaitingText;

     [Header("Result UI")]
     public Text ResultText;
     // Start is called before the first frame update
     void Start()
     {
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.Confined;

          UIFade.StartFadeIn();
          WaitingText.gameObject.SetActive(false);
          ResultText.text = "My Score : " + GameResult.MyClearScore + 
               "\nOther Score : " + GameResult.OtherClearScore + "\n" + 
               GameResult.GetWinner();
     }
     public void RestartGame()
     {
          UIFade.StartFadeOut();
          Invoke("LoadGameScene", 1);
     }
     public void QuitScene()
     {
          UIFade.StartFadeOut();
          Invoke("LoadStartScene", 1);
     }

     void LoadStartScene()
     {
          StartCoroutine(GoStartScene());
     }
     void LoadGameScene()
     {
          StartCoroutine(GoGameScene());
     }

     IEnumerator GoStartScene()
     {
          WaitingText.gameObject.SetActive(true);

          AsyncOperation asyncOper = SceneManager.LoadSceneAsync("StartScene");
          while (!asyncOper.isDone)
          {
               yield return null;
          }
     }

     IEnumerator GoGameScene()
     {
          WaitingText.gameObject.SetActive(true);

          AsyncOperation asyncOper = SceneManager.LoadSceneAsync("GameScene");
          while (!asyncOper.isDone)
          {
               yield return null;
          }
     }
}
