using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject enemy;
    bool[] keyflag=new bool[4]{false,false,false,false};
    int hp=3;
    IEnumerator Shot(){
        while (true){
            if(Input.GetKey(KeyCode.Z)){
                GameObject obj = Instantiate(bullet);
                Vector2 vec = transform.position;
                obj.GetComponent<Bullet>().initXY(vec.x,vec.y,0.0f,0.2f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "enemy_bullet"){
            hp--;
        }
        if(hp==0)Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move();
    }
    void Move(){
        int[] dx=new int[4]{0,0,1,-1};
        int[] dy=new int[4]{1,-1,0,0};
        keyflag[0]=Input.GetKey(KeyCode.UpArrow);
        keyflag[1]=Input.GetKey(KeyCode.DownArrow);
        keyflag[2]=Input.GetKey(KeyCode.RightArrow);
        keyflag[3]=Input.GetKey(KeyCode.LeftArrow);
        for(int i=0;i<4;i++){
            if(keyflag[i]){
                var vec=transform.position;
                vec.x+=dx[i]*0.01f;
                vec.y+=dy[i]*0.01f;
                transform.position=vec;
            }
        }
    }
    void Update(){}
}
