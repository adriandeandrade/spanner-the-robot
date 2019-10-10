using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    // Inspector Fields
    [Header ("Collision Settings")]
    [SerializeField] private int numberOfRays = 10;

    // Private Variables
    private Vector2 startPoint;
    private Vector2 originPoint;
    private int horizontalRayCount;
    private int verticalRayCount;
    private const float margin = 0.015f;
    private float lengthOfRay;
    private float distanceBetweenRays;
    private float directionFactor;

    // Components
    private RaycastOrigins rays;
    private Collider2D col;
    private RaycastHit2D hitInfo;
    private Ray2D ray;

    private void Awake ()
    {
        col = GetComponent<Collider2D> ();
    }

    private void Start ()
    {
        lengthOfRay = col.bounds.extents.x;
        directionFactor = Mathf.Sign (Vector2.right.x);
    }

    private void Update ()
    {
        if (IsCollidingHorizontally ())
        {
            Debug.Log ("Colliding Horizontally");
        }

        startPoint = new Vector2 (col.bounds.max.x, col.bounds.min.y);
    }

    private void UpdateRaycastOrigins ()
    {
        Bounds bounds = col.bounds;
        bounds.Expand (margin * -2);

        rays.down = new Vector2 (bounds.min.x, bounds.min.y);
        rays.right = new Vector2 (bounds.max.x, bounds.min.y);
        rays.left = new Vector2 (bounds.min.x, bounds.min.y);
        rays.down = new Vector2 (bounds.min.x, bounds.min.y);
    }

    private void CalculateRaySpacing()
    {
        Bounds bounds = col.bounds;
        bounds.Expand (margin * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;
    }

    private bool IsCollidingHorizontally ()
    {
        originPoint = startPoint;
        distanceBetweenRays = (col.bounds.size.y - 2 * margin) / (numberOfRays - 1);

        for (int i = 0; i < numberOfRays; i++)
        {
            ray = new Ray2D (originPoint, Vector2.right * directionFactor);
            Debug.DrawRay (originPoint, Vector2.right * directionFactor, Color.yellow);

            if (Physics2D.Raycast (ray.origin, Vector2.right * directionFactor))
            {
                return true;
            }

            originPoint += new Vector2 (0, distanceBetweenRays);
        }

        return false;
    }

    private bool IsCollidingVertically ()
    {
        return false;
    }

    public struct RaycastOrigins
    {
        public Vector2 down;
        public Vector2 up;
        public Vector2 right;
        public Vector2 left;
    }
}