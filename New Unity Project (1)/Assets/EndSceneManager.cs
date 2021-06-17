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
     [Header("Result UI")]
     public Text ResultText;
     // Start is called before the first frame update
     void Start()
     {
          Screen.SetResolution(1920, 1080, false);
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.Confined;

          UIFade.StartFadeIn();
          ResultText.text = "Score : " + GameResult.ClearScore;
     }
     public void RestartGame()
     {
          UIFade.StartFadeOut();
          Invoke("LoadStartScene", 1);
     }
     public void QuitScene()
     {
          UIFade.StartFadeOut();
          Invoke("LoadStartScene", 1);
     }

     void LoadStartScene()
     {
          SceneManager.LoadScene("StartScene");
     }
     void LoadGameScene()
     {
          SceneManager.LoadScene("GameScene");
     }
}
