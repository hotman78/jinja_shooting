using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{
    //private GameObject textGUI=GameObject.Find("Text");
    Func<float,float,Vector2> init;
    Func<float,float,float,Vector2> nextTo;
    int frameCount=0;
    int hp;
    public void Create(int _hp,Func<float,float,Vector2> _init,Func<float,float,float,Vector2> _nextTo){
        hp=_hp;
        init=_init;
        nextTo=_nextTo;
        Vector2 vec = transform.position;
        float x=vec.x,y=vec.y;
        Vector2 res=init(x,y);
        transform.position=res;
    }
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void FixedUpdate(){
        if(nextTo==null)return;
        Vector2 vec = transform.position;
        float x=vec.x,y=vec.y;
        Vector2 res=nextTo(x,y,frameCount);
        transform.position=res;
        frameCount++;
    }
    void OnTriggerEnter2D(Collider2D other){
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "player_bullet"){
            hp--;
        }
        if(hp==0)Destroy(this.gameObject);
    }
}
