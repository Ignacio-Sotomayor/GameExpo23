using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    public GameObject[] EnemyPrefabs;

    private Transform CoinTransform;

    public int valor;
    private GameObject gestor;


    void Start(){
        CoinTransform = GetComponent<Transform>();
        gestor = GameObject.FindWithTag("Gestor");
    }

    public void Activate(){
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Player"))
        {
            int enemyIndex = Random.Range(0, EnemyPrefabs.Length);
            Vector3 spawn = new Vector3(CoinTransform.position.x, CoinTransform.position.y + 5, CoinTransform.position.z);

            gestor.GetComponent<gestorPuntos>().setReliquias(1);
            gestor.GetComponent<gestorPuntos>().setPuntos(valor);

            gameObject.SetActive(false);
            
            Instantiate(EnemyPrefabs[enemyIndex], spawn, EnemyPrefabs[enemyIndex].transform.rotation);

        }
    }
    
}
