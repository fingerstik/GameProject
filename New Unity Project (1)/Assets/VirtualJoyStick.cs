using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능 지원

public class VirtualJoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
     public CharacterController characterController;

     [SerializeField]
     private RectTransform lever;
     private RectTransform rectTransform;

     [SerializeField, Range(10f, 200f)]
     private float leverRange;

     [SerializeField, Range(1f, 5f)]
     private float maxSpeed;

     private Vector2 inputVector;
     private bool isInput;

     private void Awake()
     {
          rectTransform = GetComponent<RectTransform>();
     }

     public void OnBeginDrag(PointerEventData eventData)
     {
          /*var inputDir = eventData.position - rectTransform.anchoredPosition;
          var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;
          //lever.anchoredPosition = inputDir;
          lever.anchoredPosition = clampedDir;
          */
          ControlJoystickLever(eventData);
          isInput = true;
    }
    
    // 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트
    //하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않음
    public void OnDrag(PointerEventData eventData)
     {
          /*var inputDir = eventData.position - rectTransform.anchoredPosition;
          var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;
          //lever.anchoredPosition = inputDir;
          lever.anchoredPosition = clampedDir;
          */
          ControlJoystickLever(eventData);
     }

     public void ControlJoystickLever(PointerEventData eventData)
     {
          var inputDir = eventData.position - rectTransform.anchoredPosition;
          var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;
          lever.anchoredPosition = clampedDir;
          inputVector = clampedDir / leverRange;
     }


     public void OnEndDrag(PointerEventData eventData)
     {
          isInput = false;
          lever.anchoredPosition = Vector2.zero;
     }

     private void InputControlVector()
     {
          Debug.Log(inputVector.x + " / " + inputVector.y);
          if (characterController)
          {
               Vector3 moveVector;
               moveVector.x = inputVector.x;
               moveVector.y = 0;
               moveVector.z = inputVector.y;
               characterController.Move(moveVector*maxSpeed);
          }
     }

     void Update()
     {
          if(isInput)
          {
               InputControlVector();
          }
     }

}
