﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public event UnityAction<Block> BlockCollided;
    public event UnityAction<int> BonusCollected;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 newPossition)
    {
        _rigidbody2D.MovePosition(newPossition);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            BlockCollided?.Invoke(block);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out Bonus bonus))
        {
            BonusCollected.Invoke(bonus.Collect());
        }
    }
 
}
