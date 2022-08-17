using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f; //How often is the cycle to the next sprite - before the next "move-motion"

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime); //call AnimateSprite every amount of animationTime
    }

    //Animation of the Sprites in the animationSprites array - basically it changes from picture 1 to picture 2 every second.
    private void AnimateSprite()
    {
        //Increasing the animationFrame and resetting it when it reaches the boundaries of the animationSprites array length.
        _animationFrame++;
        if(_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
