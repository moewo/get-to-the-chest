using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite openedChest;
    
    public GameObject star;

    public Vector2 spawnPos;

    public float waitTime;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("yay!");
            sr.sprite = openedChest;
            StartCoroutine(SpawnStar());
        }
    }
    
    IEnumerator SpawnStar()
    {
        while (true)
        {
            Instantiate(star, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
