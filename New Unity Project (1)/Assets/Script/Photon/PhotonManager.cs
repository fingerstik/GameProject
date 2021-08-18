using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
     private void Awake()
     {
          PhotonNetwork.SendRate = 60;
          PhotonNetwork.SerializationRate = 30;
     }

     public void Connect() => PhotonNetwork.ConnectUsingSettings();

     public override void OnConnectedToMaster()
     {
          PhotonNetwork.LocalPlayer.NickName = "Player 2";
          PhotonNetwork.JoinRoom("Cooked");
          Debug.Log(PhotonNetwork.LocalPlayer.NickName);
     }

     public override void OnJoinRoomFailed(short returnCode, string message)
     {
          PhotonNetwork.LocalPlayer.NickName = "Player 1";
          Debug.Log(PhotonNetwork.LocalPlayer.NickName);
          PhotonNetwork.CreateRoom("Cooked", new RoomOptions { MaxPlayers = 2 }, null);
     }

     public bool IsHost()
     {
          return PhotonNetwork.LocalPlayer.NickName == "Player 1" ? true : false;
     }

     public bool IsRoomFull()
     {
          if(PhotonNetwork.CurrentRoom != null)
          {
               if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
                    return false;
               else
                    return true;
          }
          else
               return false;
     }
}
