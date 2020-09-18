using System;
using System.Collections;
using System.Collections.Generic;
using AF.Movement;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void UpdatePlayerPosition(Vector2 position)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(position.x, position.y);
    }

    private void Portals()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;
            if (player.transform.position.x > 0)
            {
                UpdatePlayerPosition(new Vector2(portal.transform.position.x + 1, player.transform.position.y));                
            }
            else
            {
                UpdatePlayerPosition(new Vector2(portal.transform.position.x - 1, player.transform.position.y));
            }
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("hi");
            Portals();
        }
    }
}