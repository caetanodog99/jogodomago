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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rigidbody.linearVelocity = new Vector2(0, this.velY);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("inimigo"))
        {
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.Destruir(true);
            Destroy(this.gameObject);
        }
    }


}
