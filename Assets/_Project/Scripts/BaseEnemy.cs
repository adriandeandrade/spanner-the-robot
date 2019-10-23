using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    // Inspector Fields


    public void Kill()
    {
        Destroy(gameObject);
    }
}
