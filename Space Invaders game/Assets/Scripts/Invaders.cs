using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public int rows = 5;
    public int columns = 11;
    public Invader[] prefabs;
    public float speed = 1.0f;
    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (this.columns - 1); //the width of the screen
            float height = 2.0f * (this.rows - 1); //the height of the screen
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0);
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform); //creating the invader

                //setting the starting position for the invaders, while spacing them apart from each other
                Vector3 position = rowPosition; 
                position.x += col * 2.0f;
                //using localPosition instead of Position is crucial here: we don't want to set the position of the parent as well...
                invader.transform.localPosition = position;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the Invaders::
        this.transform.position += _direction * this.speed * Time.deltaTime; //The movement itself (right or left)
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); //Left edge of the screen
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); //Right edge of the screen

        foreach (Transform invader in this.transform) //For: Transform of each Invader
        {
            if (!invader.gameObject.activeInHierarchy) //The Invader is not active on screen
            {
                continue;
            }

            if(_direction == Vector3.right && invader.position.x >= rightEdge.x) //the dir is right & the invader is on the edge of the screen
            {
                AdvanceRow();
            }

            else if(_direction == Vector3.left && invader.position.x <= leftEdge.x) //the dir is left & the invader is on the edge of the screen
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f; //flipping the direction from right to left (or vice versa)

        Vector3 position = this.transform.position; //The current position
        position.y -= 1.0f; //Moving the position down a row
        this.transform.position = position; 
    }
}
