using System;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
   [SerializeField] private float lateralSpeed;
   [SerializeField] private float forwardSpeed;

   private void Update()
   {
      SwipeControl();
      GoForward();
   }

   private void SwipeControl()
   {
      if (Input.touchCount <= 0) return; // If we don't have any touch on screen, return

      var touch = Input.GetTouch(0); // Name the first touch
      
      if (touch.phase == TouchPhase.Moved) // If the touch is moving
      {
         transform.Translate(touch.deltaPosition.x * lateralSpeed/10, 0, 0);
         
         AdjustPosition(2);
      }
   }

   private void AdjustPosition(float limit) // To limit our objects lateral position, X is transform position
   {
      var currentPosition = transform.localPosition;

      if (currentPosition.x > limit)
      {
         transform.localPosition = new Vector3(limit, currentPosition.y, currentPosition.z);
      }

      if (currentPosition.x < -limit)
      {
         transform.localPosition = new Vector3(-limit, currentPosition.y, currentPosition.z);
      }
   }

   private void GoForward() // Make object go forwards
   {
      transform.position += transform.forward * forwardSpeed/10;
   }
}
