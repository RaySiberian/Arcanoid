using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjects : MonoBehaviour
{
    [SerializeField] private int durability;
    [SerializeField] private int scoreToAdd;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private bool isUnBreakable;
    [SerializeField] private bool isInvisible;
    
        
    private int _spriteIndex = 0;

    public static event Action<int> OnBlockDestroyed;

    private void Start()
    {
        if (isInvisible)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isUnBreakable && !isInvisible)
        {
            SelfDamage();
        }
        
        if (isInvisible)
        {
            isInvisible = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    private void SelfDamage()
    {
        durability--;
        if (durability <= 0)
        {
            OnBlockDestroyed?.Invoke(scoreToAdd);
            Destroy(gameObject);
        }
        
        _spriteIndex++;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_spriteIndex];
    }
}
