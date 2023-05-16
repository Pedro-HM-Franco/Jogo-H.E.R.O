using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguircamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public float velocidadeMovimento = 5f;

    void Update()
    {
        // Obtém a posição do mouse no mundo
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicaoMouse.z = transform.position.z;

        // Move a câmera em direção à posição do mouse suavemente
        transform.position = Vector3.Lerp(transform.position, posicaoMouse, velocidadeMovimento * Time.deltaTime);
    }
}
