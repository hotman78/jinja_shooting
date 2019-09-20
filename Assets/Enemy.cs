using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;
    public GameObject textGUI;
    public GameObject bullet;
    public int x;


    IEnumerator Shoot()
    {

        while (true)
        {
            GameObject obj = Instantiate(bullet);
            Vector2 vec = transform.position;
            obj.GetComponent<Bullet>().initXY(vec.x, vec.y, 0.0f, -0.2f);
            yield return new WaitForSeconds(0.1f);
        }
        // 何か処理


    }
    // Start is called before the first frame update
    void Start()
    {

        textGUI=GameObject.Find("Text");
　　　　 int seed = Environment.TickCount;
        System.Random rnd = new System.Random();
        x = rnd.Next(-20,20);
        Vector2 vec=new Vector2();
        vec.x = x;
        vec.y = 10;
        Debug.Log(x);
        enemy.transform.position = vec;
        StartCoroutine(Shoot());

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 vec = enemy.transform.position;
        vec.y -= 0.05f;

        enemy.transform.position = vec;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Player")
        {
            Destroy(collision.gameObject);
            textGUI.GetComponent<Text>().text = "デデドン！（絶望）"; //Kill Player
        }

        
    }
}
