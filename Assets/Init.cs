using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour{
    public GameObject player;
    void Start(){
        Instantiate(player);
        Vector2 vec = new Vector2();
        vec.x = 0.0f;
        vec.y = 0.0f;
        player.transform.position = vec;

    }
}
