using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public int rows = 5;
    public int columns = 11;
    public Invader[] prefabs;

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0);
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform); //creating the invader

                //setting the position for the invader, while spacing them apart from each other
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
        
    }
}
