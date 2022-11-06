using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class fallingLemon : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector2 start;
    float rot;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        start = transform.position;
        rot = Random.Range(-10f, 10f);

    }



    private void FixedUpdate()
    {

        if (transform.position.y < 0) {

            transform.position = start;
            rot = Random.Range(-10f, 10f);
            rb2d.velocity = Vector2.zero;

        }

        rb2d.transform.Rotate(new Vector3(0,0,rot));

    }

}
