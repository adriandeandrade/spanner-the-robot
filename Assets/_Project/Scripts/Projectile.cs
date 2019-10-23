using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    private float velocity = 5f;

    public void InitBullet(Vector2 moveDirection)
    {
        direction = moveDirection;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }
}
