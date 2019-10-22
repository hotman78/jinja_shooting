using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;
public class Init : MonoBehaviour{
    public GameObject player;
    public GameObject enemy;
    public GameObject bullet;
    SortedList EventList = new SortedList();
    int eventCount=0;
    int frameCount=0;
    bool appear=false;
    void Start(){
        Instantiate(player);
        for(int i=0;i<10;i++){
            CreateEnemy(i*100,i,(x,y)=>{
                return new Vector2(0f,1f);
            },
            (x,y,t)=>{
                if(t%10==0)CreateBulletRθ(x,y,0.02f,t*0.1f);
                return new Vector2(x+0.01f*(float)Math.Sin(t*0.1f),y-0.01f);
            });
        }
    }
    void CreateEnemy(int frame,int hp,Func<float,float,Vector2> init,Func<float,float,float,Vector2> nextTo){
        EventList.Add(frame,new Tuple<int,Func<float,float,Vector2>,Func<float,float,float,Vector2>>(hp,init,nextTo));
    }
    void CreateBulletXY(float x,float y,float vx=0,float vy=0,float ax=0,float ay=0){
        GameObject obj = Instantiate(bullet);
        Vector2 vec = transform.position;
        obj.GetComponent<Bullet>().initXY(x,y,vx,vy,ax,ay);
    }
    void CreateBulletRθ(float x,float y,float vr=0,float vθ=0,float ar=0,float aθ=0){
        GameObject obj = Instantiate(bullet);
        Vector2 vec = transform.position;
        obj.GetComponent<Bullet>().initRθ(x,y,vr,vθ,ar,aθ);
    }
    void FixedUpdate(){
        while(EventList.Count>eventCount&&(int)EventList.GetKey(eventCount)==frameCount){
            GameObject obj=Instantiate(enemy);
            (int hp,Func<float,float,Vector2> init,Func<float,float,float,Vector2> nextTo)
                =(Tuple<int,Func<float,float,Vector2>,Func<float,float,float,Vector2>>)EventList.GetByIndex(eventCount);
            obj.GetComponent<Enemy>().Create(hp,init,nextTo);
            eventCount++;
        }
        frameCount++;
    }
}
