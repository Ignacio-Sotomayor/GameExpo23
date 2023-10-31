using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    
    public float EnemySpeed = 5f;
    public float RotationSpeed = 10f;

    private Transform enemy;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Voltear
        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), RotationSpeed * Time.deltaTime);

        enemy.position += enemy.forward * EnemySpeed * Time.deltaTime;

        Debug.DrawLine(player.transform.position, transform.position, Color.red, Time.deltaTime, false);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Game Over !!!");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
