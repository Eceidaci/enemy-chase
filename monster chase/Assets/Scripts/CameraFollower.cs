using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;  //kameranýn pozisyonu
   
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        if(player==null) return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;
    }
}
