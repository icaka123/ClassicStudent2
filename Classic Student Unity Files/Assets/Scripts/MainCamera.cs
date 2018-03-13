using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public int n = 3;
    private Vector2 velocity;
    public float smoothTimeY; 
    public float smoothTimeX; // С колко да е по назад камерата от човечето
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y+n, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
        //Движение на "Main Camera" заедно с героя
    }


 
}
