using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject explosaoPrefab;
    public float tempoExplosao = 2f;
   
    void Start()
    {
         Invoke("Explodir", tempoExplosao);
    }

    private void Explodir()
    {
        // Instancia a explosão no mesmo local da bomba
        Instantiate(explosaoPrefab, transform.position, Quaternion.identity);

        // Destroi a bomba
        Destroy(gameObject);
    }

    // Update is called once per frame
   void Update()
    {
    

    }


}
