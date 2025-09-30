using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scriptmalvado : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velMin;
    public float velMax;

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
    }

    public void Destruir() 
    {
        pontuacao.Pontos++;
        Destroy(this.gameObject);
    }
}
