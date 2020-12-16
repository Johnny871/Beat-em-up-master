using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-9.0f);
    }
}
