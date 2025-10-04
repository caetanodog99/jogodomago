using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class scriptmalvado : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velMin;
    public float velMax;
    public int vida;

    private float velY;



    void awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        this.velY = Random.Range(this.velMin, this.velMax);
    }

    
    void Update()
    {
        this.rigidbody.linearVelocity = new Vector2(0,-this.velY);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y < 0)
        {
            scriptmago player = GameObject.FindGameObjectWithTag("Player").GetComponent<scriptmago>();
            player.PerderVida--;
            Destruir(false);
        }
    }

    public void ReceberDano()
    {
        this.vida--;
        if (vida <= 0)
        {
            Destruir(true); 
        }
    }

    private void Destruir(bool derrotado) 
    {
        if (derrotado)
        {
            pontuacao.Pontos++;
        }
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        if (gameObject.CompareTag("Boss"))
        {
            malvadosManager manager = FindObjectOfType<malvadosManager>();
            if (manager != null)
            {
               manager.TelaDeVitoria(); 
            }
        }
    }
}
