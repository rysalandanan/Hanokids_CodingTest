using System.Collections;
using UnityEngine;

public class AnimalAction : MonoBehaviour
{
    [Header("MOVEMENT")]
    [Header("Travel Destinations: ")]
    [SerializeField] private Transform[] travelPoints;
    [Header("Animal's movement speed: ")]
    [SerializeField] private float movementSpeed;

    [Header("NON - MOVEMENT")]
    [SerializeField] private float animationTime;
    
    [SerializeField] private bool facingRight;

    private Rigidbody2D rb;
    private int currentPointIndex = 0;
    private bool isMoving = false;
    private bool isStationaryAnimationPlaying = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CheckNull();
    }
    public void StartMoving()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToNextPoint());
        }
    }
    public void StartStationaryAnimation()
    {
        if(!isStationaryAnimationPlaying)
        {
            StartCoroutine(StationaryAnimation());
        }
    }
    private void Update()
    {
        if (rb != null)
        {
            SpriteFlip();
        }
    }
    private IEnumerator MoveToNextPoint()
    {
        isMoving = true;
        Transform targetPoint = travelPoints[currentPointIndex];

        while (Vector2.Distance(transform.position, targetPoint.position) > 0.1f)
        {
            Vector2 direction = (targetPoint.position - transform.position).normalized;
            Vector2 force = direction * movementSpeed;
            rb.AddForce(force);
            yield return null;
        }
        rb.velocity = Vector2.zero;
        isMoving = false;
        currentPointIndex = (currentPointIndex + 1) % travelPoints.Length;
    }
    private IEnumerator StationaryAnimation()
    {
        isStationaryAnimationPlaying = true;
        yield return new WaitForSeconds(animationTime);
        isStationaryAnimationPlaying = false;
    }
    private void SpriteFlip()
    {
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        facingRight = !facingRight; 
    }
    public bool IsMoving()
    {
        return isMoving;
    }
    public bool IsStationaryAnimationPlaying()
    {
        return isStationaryAnimationPlaying;
    }
    private void CheckNull()
    {
        string error = "is not assigned or invalid on " + gameObject.name;

        if(rb == null)
        {
            Debug.LogError("Rigidbody" + error);
        }
        if(travelPoints.Length == 0)
        {
            Debug.LogError("Travel Points Array" + error);
        }
        if(float.IsNaN(movementSpeed))
        {
            Debug.LogError("Movement Speed" + error);
        }
        if(float.IsNaN(animationTime))
        {
            Debug.LogError("Animation Time" + error);
        }
    }
}
