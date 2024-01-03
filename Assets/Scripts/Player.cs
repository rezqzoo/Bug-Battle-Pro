using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private Vector3 _startPosition = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        //take the starting position = new position (0, 0, 0)
        transform.position = _startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //pull Inputs from the Unity Project Settings editor Input settings into a variable
        //so that we can use a controller or keyboard inputs to handle player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //This commented out Translate code uses two "new" calls; one per Vector3,
        //and it's cluttered, but it works perfectly.
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        //optimized for performance (only one Vector3 "new" call) and readability

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(_speed * Time.deltaTime * direction);


        //if player postion on y-axis is greater than 0, then position = 0

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);//retains correct x-position    
        }
        else if (transform.position.y < -3.8)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        //if player on x-axis > 11, x = -11, else if x < -11, x = 11
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }
}
