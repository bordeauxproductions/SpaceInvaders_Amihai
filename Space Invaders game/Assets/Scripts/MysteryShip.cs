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
    private bool isActive;
    private Vector3 direction = Vector2.right;

    private void Awake()
    {
        this.gameObject.SetActive(false);
        isActive = false;
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

       /* if (this.transform.position.x >= 14.0f) //TODO::change this to Right edge of screen Instead of Magic Number
        {
            isActive = false;
            this.transform.position = orgPosition;
            this.gameObject.SetActive(false); //we have reached the end of the screen
        } */
    }

    private void mysteryShipMovement()
    {
       // var rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); //Right edge of the screen
        isActive = true;
        this.gameObject.SetActive(true);
       // this.GetComponent<Rigidbody>().AddForce(speed, 0.0f, 0.0f);

        /*if (isActive && this.transform.position.x < rightEdge.x)
        {
            //do nothing;
        }

        if (isActive)
        {
            hitOrOutOfScreen();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Making sure that the collision is with a laser
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser") ||
            collision.gameObject.layer == LayerMask.NameToLayer("RightBorder"))
        {
            isActive = false;
            this.transform.position = orgPosition;
            this.gameObject.SetActive(false); //we have been hit by a laser or we have reached the right border

            //TODO:: Add logic of adding score if the ship was hit by the laser
        }
    }

   /* private void FlipRow()
    {
        _direction.x *= -1.0f; //flipping the direction from right to left (or vice versa)
        position = this.transform.position;
        this.transform.position = position;
    }*/
}
