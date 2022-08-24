using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using Unity.VisualScripting;

public class MysteryShip : MonoBehaviour
{
    private Vector3 orgPosition;
    private float delay = 1.0f;
    private float repeatTime = 10.0f;
    private float speed = 15.0f;
    private Vector3 direction = Vector2.right;
    [SerializeField] private int score = 500;
    [SerializeField] private AudioSource spaceShipEntry;
    [SerializeField] private AudioSource spaceShipHit;

    private void Awake()
    {
        this.gameObject.SetActive(false);
        orgPosition = this.transform.position;
        InvokeRepeating(nameof(mysteryShipMovement), delay, repeatTime);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var position = new Vector3(direction.x * speed * Time.deltaTime, 0.0f, 0.0f);
        this.transform.position += position; //moving the Mystery Ship to the right
       // GetComponent<Rigidbody2D>().AddForce(new Vector3((new Vector2()).x * speed, orgPosition.y, 0.0f), ForceMode2D.Impulse);
    }

    private void mysteryShipMovement()
    {
        this.gameObject.SetActive(true);
        spaceShipEntry.Play(); //sound effect
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Making sure that the collision is with a laser or a border
        if (!(collision.gameObject.layer == LayerMask.NameToLayer("Laser") ||
            collision.gameObject.layer == LayerMask.NameToLayer("RightBorder"))) return;

        //we have been hit by a laser or we have reached the right border
        spaceShipEntry.Stop();
        this.transform.position = orgPosition;
        this.gameObject.SetActive(false); 

        //if the collision was with the player's Laser
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            spaceShipHit.Play(); //sound effect
            GameManager.Instance.UpdateScore(score);
        }
    }
}
