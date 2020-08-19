using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public float moveSpeed;
   public float zoomSpeed;

   public float minZoomDist;
   public float maxZoomDist;

   private Camera _camera;

   private void Awake()
   {
      _camera = Camera.main;
   }

   private void Update()
   {
      Move();
      Zoom();
   }

   void Move()
   {
      float xInput = Input.GetAxis("Horizontal");
      float zInput = Input.GetAxis("Vertical");

      Vector3 dir = transform.forward * zInput + transform.right * xInput;
      transform.position += dir * moveSpeed * Time.deltaTime;
   }

   void Zoom()
   {
      float scrollInput = Input.GetAxis("Mouse ScrollWheel");
      float dist = Vector3.Distance(transform.position, _camera.transform.position);

      if (dist < minZoomDist && scrollInput > 0f)
      {
         return;
      }
      else if(dist > maxZoomDist && scrollInput < 0f)
      {
         return;
      }

      _camera.transform.position += _camera.transform.forward * scrollInput * moveSpeed;
   }

   public void FocusOnPosition(Vector3 pos)
   {
      transform.position = pos;
   }
}
