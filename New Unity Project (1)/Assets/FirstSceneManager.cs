using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
     public PhotonManager phManager;
     public Text WaitingText;

     public void Start()
     {
          WaitingText.gameObject.SetActive(false);
     }
     
     public void EndGame()    
     {
#if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
     }

     public void GoGameScene()
     {
          StartCoroutine("LoadScene", "GameScene");
     }

     IEnumerator LoadScene(string sceneName)
     {
          phManager.Connect();
          //UIFade.StartFadeOut();
          yield return new WaitForSeconds(1.0f);
          if (phManager.IsHost())
          {
               WaitingText.text = "Player is Host\n" + WaitingText.text;
          }
          else
          {
               WaitingText.text = "Player is Client\n" + WaitingText.text;
          }
          WaitingText.gameObject.SetActive(true);

          while (!phManager.IsRoomFull())
          {
               yield return null;
          }
          AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
          while(!asyncOper.isDone)
          {
               yield return null;
          }
     }
}
