using UnityEngine;
using UnityEngine.Rendering;

public class boladefogo : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velY;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.rigidbody.linearVelocity = new Vector2(0, this.velY);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y > 1)
        {
            Destroy(this.gameObject); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.ReceberDano();
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Boss"))
        {
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.ReceberDano();
            Destroy(this.gameObject);
        }

    }


}
