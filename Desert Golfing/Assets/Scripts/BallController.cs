using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;

    float shotPower = 0f;
    public float maxShotPower;
    
    bool playingShot = false;

    Vector2 startAim;
    Vector2 shotDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Check if shot started
        if (Input.GetMouseButtonDown(0) && rb.velocity.magnitude == 0f)
        {
            playingShot = true;
            startAim = mousePosition;
        }

        // Set shot direction & power
        if (playingShot)
        {
            shotDirection = startAim - mousePosition;
            shotDirection.Normalize();
            shotPower = maxShotPower;
        }

        // Play shot
        if (Input.GetMouseButtonUp(0) && playingShot)
        {
            playingShot = false;
            rb.AddForce(shotDirection * shotPower);
        }
    }
}
