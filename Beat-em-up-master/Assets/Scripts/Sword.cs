using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    Renderer targetRenderer;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();	
    }

    
    void Update(){
        this.transform.Translate(0.1f,0,0);
        if(targetRenderer.isVisible){
        }else{
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player"){
            Debug.Log(other.gameObject);
            this.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Enemy"){
            AudioManager.Instance.Hit();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
