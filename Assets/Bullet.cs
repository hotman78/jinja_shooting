using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    public GameObject player;
    public GameObject bullet;
    private int state;
    private float vx,vy,ax,ay;
    private float vr,vθ,ar,aθ;
    // Start is called before the first frame update
    void Start(){
        Vector2 vec = player.transform.position;
        bullet.transform.position = vec;
    }
    public void initXY(float x,float y,float vx=0,float vy=0,float ax=0,float ay=0){
        Vector2 vec = player.transform.position;
        state=0;
        vec.x=x;
        vec.y=y;
        this.vx=vx;
        this.vy=vy;
        this.ax=ax;
        this.ay=ay;
    }
    public void initRθ(float x,float y,float vr=0,float vθ=0,float ar=0,float aθ=0){
        Vector2 vec = player.transform.position;
        state=1;
        vec.x=x;
        vec.y=y;
        this.vr=vr;
        this.vθ=vθ;
        this.ar=ar;
        this.aθ=aθ;
    }
    // Update is called once per frame
    void FixedUpdate(){
        Vector2 vec = bullet.transform.position;
        switch(state){
            case 0:{
                vx+=ax;
                vy+=ay;
                vec.x +=vx;
                vec.y +=vy;
                break;
            }
            case 1:{
                vr+=ar;
                vθ+=aθ;
                vec.x+=vr*Mathf.Cos(vθ);
                vec.y+=vr*Mathf.Sin(vθ);
                break;
            }
        }
        bullet.transform.position = vec;
    }

}
