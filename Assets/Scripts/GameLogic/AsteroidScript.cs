using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [Header("Asteroid settings")]
    [SerializeField] float travelSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * travelSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // In case we want to do more here like count points etc.
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
