using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestorPuntos : MonoBehaviour
{
    private int Reliquias;
    private int Puntos;

    public GameObject[] Objects;
    public Text mensage;

    public void setReliquias(int cantidad)
    {
        Reliquias += cantidad;
        StartCoroutine(Activador());
    }

    void Start()
    {
    }

    void Update()
    {
        mensage.text = "Puntos: " + Puntos + "\n" + "Reliquias: " + Reliquias;

    }

    IEnumerator Activador()
    {
        if (Reliquias % 3 == 0 && Reliquias != 0)
        {
            foreach (GameObject item in Objects)
            {
                Debug.Log("Activada");
                yield return new WaitForSeconds(1.5f);
                item.GetComponent<CoinController>().Activate();
            }
        }
    }

    public void setPuntos(int cantidad) { Puntos += cantidad; }

}
