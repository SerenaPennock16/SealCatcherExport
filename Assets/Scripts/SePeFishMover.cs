﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePeFishMover : MonoBehaviour { 

public float speed;
private Rigidbody2D rb2d;

private void Start()
{
    rb2d = GetComponent<Rigidbody2D>();
    rb2d.velocity = transform.forward * speed;
}

}
