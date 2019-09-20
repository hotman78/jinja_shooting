using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject enemy;
    

    IEnumerator Shoot()
    {
        
        while (true)
        {
            GameObject obj = Instantiate(bullet);
            Vector2 vec = bullet.transform.position;
            obj.GetComponent<Bullet>().initXY(vec.x,vec.y,0.0f,0.2f);
            yield return new WaitForSeconds(0.1f);
        }
        // 何か処理


    }

    IEnumerator CreateEnemy()
    {

        while (true)
        {

            GameObject obj = Instantiate(enemy);
            yield return new WaitForSeconds(0.1f);
        }
        // 何か処理


    }

    void OnTriggerEnter2D(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if (layerName == "enemy")
        {
            Destroy(player);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 vec = player.transform.position;

            vec.y += 0.1f;

            player.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 vec = player.transform.position;

            vec.y -= 0.1f;

            player.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 vec = player.transform.position;

            vec.x -= 0.1f;

            player.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 vec = player.transform.position;

            vec.x += 0.1f;

            player.transform.position = vec;
        }
    }
}
