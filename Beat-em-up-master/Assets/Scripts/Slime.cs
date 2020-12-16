using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    [SerializeField] private float speed =  4f;

    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D =  gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Ground") return;
        this.gameObject.transform.localScale = new Vector3(this.transform.localScale.x * -1.0f,this.transform.localScale.y,this.transform.localScale.z);
        speed *= -1.0f;
    }
}
