using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Chasing : MonoBehaviour
{
     public GameObject Player;
     private GameObject Target;
     public float CameraX;
     public float CameraY;
     public float CameraZ;
     private void Start()
     {

          Target = Player;
          Vector3 TargetPos = new Vector3(Target.transform.position.x + CameraX, Target.transform.position.y + CameraY, Target.transform.position.z + CameraZ);
          transform.position = TargetPos;
     }
     void FixedUpdate()
     {
          Vector3 TargetPos = new Vector3(Target.transform.position.x + CameraX, Target.transform.position.y + CameraY, Target.transform.position.z + CameraZ);
          transform.position = Vector3.Lerp(transform.position, TargetPos, MoveRateTime(Time.deltaTime * 2f, 0.5f));
     }
     float MoveRateTime(float time, float rate)
     {
          if (time <= 1)
               return time / 2;
          else
               return 0.5f;
     }
}