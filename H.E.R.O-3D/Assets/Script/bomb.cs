using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject Player;
    public float timeToExplode = 3.0f; // Tempo para a bomba explodir em segundos
    public float throwSpeed = 5.0f; // Velocidade de lançamento da bomba

   // public float speed = 10f;
    //private float destroyTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
   void Update()
{
    if (Input.GetKeyDown(KeyCode.B))
    {
        Instantiate(gameObject, Player.transform.position, Quaternion.identity);
    }

    


}


}
