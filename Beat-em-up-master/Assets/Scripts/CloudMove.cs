using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime,0,0);
        if(this.transform.position.x >= 16.0f){
            this.transform.position = new Vector3(-16.0f,0,0);
        }
    }
}
