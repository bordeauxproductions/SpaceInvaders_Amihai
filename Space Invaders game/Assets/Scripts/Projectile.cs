using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public Action destroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    //When the projectile (laser) collides with something in the game - hence using the trigger box in the Collider2D in Unity.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.destroyed != null)
        {
            //Sort of a callback to notify other scripts that are using this Projectile object, that this Object is being destroyed.
            this.destroyed.Invoke();
        }
        Destroy(this.gameObject);
    }
}
