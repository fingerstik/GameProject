using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [Header("Plyaer Condition")]
     public GameObject PlayerModel;
     public GameObject PlayerItemPoint;
     public bool StopByStage;
     private bool IsMotion;
     private bool IsDash;
     private bool IsPicking;

     [Header("Player Moving")]
     public float speed;
     public float dashSpeed;
     private float DashTime;
     private float DashCoolTime;
     public VariableJoystick variableJoystick;

     [Header("Player Having")]

     [Header("Plyaer Animation")]
     public Animator ani;

     private Rigidbody playerRB;

     public void Awake()
     {
          playerRB = GetComponent<Rigidbody>();
          ani = GetComponent<Animator>();
          IsMotion = false;
          DashCoolTime = Time.time;
     }

     public void OnDashDown()
     {
          if (Time.time - DashCoolTime > 3.0f)
          {
               IsDash = true;
               ani.SetBool("isDashing", true);
               DashTime = Time.time;
               DashCoolTime = Time.time;
          }
     }
     public void OnDashUp()
     {
          IsDash = false;
          ani.SetBool("isDashing", false);
     }
     public void OnEnableDown()
     {
          if(IsPicking)
               Drop();
     }

     public void Pickup (GameObject item)
     {
          Collider[] itemColliders = item.GetComponents<Collider>();
          Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

          foreach(Collider itemCollider in itemColliders)
          {
               itemCollider.enabled = false;
          }
          itemRigidbody.isKinematic = true;

          ani.SetTrigger("Enable");
          IsPicking = true;
     }
     public void Drop ()
     {
          GameObject item = PlayerItemPoint.GetComponentInChildren<Rigidbody>().gameObject;
          Collider[] itemColliders = item.GetComponents<Collider>();
          Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

          foreach (Collider itemCollider in itemColliders)
          {
               itemCollider.enabled = true;
          }
          itemRigidbody.isKinematic = false;

          PlayerItemPoint.transform.DetachChildren();
          ani.SetTrigger("Enable");
          IsPicking = false;

     }

     public void Update()
     {
          //스테이지에 의해 행동 불능
          if (StopByStage)
          {
               ani.SetBool("isMoving", false);
               return;
          }
          Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
          if (!IsMotion)
          {
               direction = direction.normalized * speed * Time.fixedDeltaTime;
               if (direction.x == 0.0f && direction.z == 0.0f) ani.SetBool("isMoving", false);
               else ani.SetBool("isMoving", true);
               playerRB.MovePosition(transform.position + direction);
               if(direction.x != 0.0f || direction.y != 0.0f)
                    playerRB.transform.rotation = Quaternion.LookRotation(direction);
               if(Time.time - DashTime < 1.0f && IsDash)
               {
                    playerRB.MovePosition(transform.position + direction*dashSpeed);
                    if (direction.x != 0.0f || direction.y != 0.0f)
                         playerRB.transform.rotation = Quaternion.LookRotation(direction);
               }
               else OnDashUp();
          }
     }
}