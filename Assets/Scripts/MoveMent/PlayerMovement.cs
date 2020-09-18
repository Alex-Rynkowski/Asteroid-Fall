using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AF.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 10;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Movement(Vector2 direction)
        {
            rb.velocity = direction * moveSpeed;
        }
    }
}