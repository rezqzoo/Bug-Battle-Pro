using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private Vector3 _startPosition = new Vector3(0, 7, 0);


    // Start is called before the first frame update
    void Start()
    {
        Vector3 randVectorX = new Vector3(Random.Range(-8f, 8f), 0, 0);

        transform.position = _startPosition + randVectorX;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "Player")
        {
            Destroy(gameObject);
        }
        else if (other.transform.name == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
