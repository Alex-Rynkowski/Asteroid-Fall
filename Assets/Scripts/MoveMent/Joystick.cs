using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AF.Movement
{
    public class Joystick : MonoBehaviour
    {
        private Vector2 startPos;
        private Vector2 currentPosition;

        private bool touchStart = false;
        
        public Transform controller;
        public Transform controllerBorder;

        private void Start()
        {
            startPos = controller.transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                controller.GetComponent<SpriteRenderer>().enabled = true;
                controllerBorder.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (Input.GetMouseButton(0))
            {
                touchStart = true;
                 currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                     Input.mousePosition.z));
            }
            else
            {
                touchStart = false;
            }
        }

        private void FixedUpdate()
        {
            if (touchStart)
            {
                Vector2 offset = currentPosition - startPos;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1f);
                FindObjectOfType<PlayerMovement>().Movement(new Vector2(direction.x, 0));
                controller.transform.position = new Vector2(startPos.x + direction.x, startPos.y + direction.y) * 1;
            }
            else
            {
                controller.GetComponent<SpriteRenderer>().enabled = false;
                controllerBorder.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}