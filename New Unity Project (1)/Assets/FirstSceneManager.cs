using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
     public Fade UIFade;
     private float Timer;
     // Start is called before the first frame update
     void Start()
     {
          UIFade.StartFadeIn();
          Screen.SetResolution(1920, 1080, false);
     }

     // Update is called once per frame
     public void MakeLobby()
     {

     }
     public void EnterLobby()
     {

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
          UIFade.StartFadeOut();
          Invoke("LoadGameScene", 1);
     }

     void LoadGameScene()
     {
          UIFade.StartFadeOut();
          SceneManager.LoadScene("GameScene");
     }
}
