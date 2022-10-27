using System;
using UnityEngine;
using Object = System.Object;

public class Star : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = Vector2.up * speed;
    }

    private void Update()
    {
        Destroy(this.gameObject, time);
    }
}
