using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 5.0f;
    public bool _laserActive;
    private Vector3 orgPosition;

    private void Awake()
    {
        orgPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement: Left & Right 
        /*The difference between 'GetKey' and 'GetKeyDown' is that 'GetKey' will keep on changing the position if the key is pressed down,
          while 'GetKeyDown' will change it only once per frame is the key is being pressed down. */
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        //Shooting 'laser'
        //Here we want to use 'GetKeyDown' since we want to shoot only once even if the key is pressed down (and not spray automatically).
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    //Shooting the 'laser'
    private void Shoot()
    {
        //We don't want multiple lasers in the scene, only one per move (until it is gone from the scene)
        if (!_laserActive)
        {
            //Subscribe to the event
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            //Once the laserPrefab (Projectile object) was created, it will update automatically every frame - meaning the position 
            //of this specific 'laser' particle will change every frame - going upwards in the game.

            _laserActive = true; //Won't allow another laser to be shot until this one is destroyed
            projectile.destroyed += LaserDestryoed; //Now we can shoot again.
        }
    }

    private void LaserDestryoed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            //Making the player "blink"
            Invoke("EnablePlayerBlink", 0.0f);
            Invoke("DiasblePlayerBlink", 0.15f);
            GameManager.Instance.UpdateLives(0);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.UpdateLives(-1);
        }

        else if (collision.gameObject.layer == LayerMask.NameToLayer("LeftBorder"))
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.5f, orgPosition.y, orgPosition.z);
        }

        else if (collision.gameObject.layer == LayerMask.NameToLayer("RightBorder"))
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.5f, orgPosition.y, orgPosition.z);
        }
    }

    private void EnablePlayerBlink()
    {
        this.gameObject.SetActive(false);
    }

    private void DiasblePlayerBlink()
    {
        this.gameObject.SetActive(true);
    }
}
