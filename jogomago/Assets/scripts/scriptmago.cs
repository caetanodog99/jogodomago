using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class scriptmago : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public bool KeepOffset = true;
    public Camera cam;
    public int activeFingerID = -1;
    public float screenZ;
    public Vector3 dragOffset;
    [SerializeField] bool has2D; 
    [SerializeField] bool has3D;


    public boladefogo tiroprefab;
    private float intervalotiro;
    public float tempoEspera;

    private int vidas;

    private telafim telaFimJogo;


    private void Awake()
    {
       
        rigidbody = GetComponent<Rigidbody2D>();
        
        cam = Camera.main;
        has2D = GetComponent<Collider2D>() != null;
        has3D = GetComponent<Collider>() != null;
    }

    private void OnEnable()
    {
        screenZ = cam.WorldToScreenPoint(transform.position).z;
    }


    void Start()
    {
        this.vidas = 5;
        pontuacao.Pontos = 0;
        this.intervalotiro = 0;

        GameObject FimJogoObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = FimJogoObject.GetComponent<telafim>();
        this.telaFimJogo.Esconder();

    }



    void Update()
    {
        this.intervalotiro += Time.deltaTime;
        if (this.intervalotiro >= tempoEspera)
        {
            this.intervalotiro = 0;
            atirar();
        }

        if (Input.touchCount == 0) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began && activeFingerID == -1 && TouchHitsThis(touch.position))
            {
                activeFingerID = touch.fingerId;
                Vector3 worldAtFinger = ScreenToWorld(touch.position);
                dragOffset = KeepOffset ? (transform.position - worldAtFinger) : Vector3.zero;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary && touch.fingerId == activeFingerID)
            {
                Vector3 worldAtFinger = ScreenToWorld(touch.position);
                transform.position = worldAtFinger + dragOffset;
            }

            
            if (touch.fingerId == activeFingerID && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                activeFingerID = -1;
            }
        }


    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("inimigo"))
        {
            PerderVida--;  
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.ReceberDano();
        }
        if (collider.CompareTag("Boss"))
        {
            PerderVida--;
            scriptmalvado inimigo = collider.GetComponent<scriptmalvado>();
            inimigo.ReceberDano();
        }
    }

    public int PerderVida
    {
        get 
        { 
            return vidas; 
        }

        set 
        {
            this.vidas = value;
            if (vidas <= 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                telaFimJogo.Exibir();
             
            }
        }


    }


    private void atirar()
    {
        Instantiate(this.tiroprefab, this.transform.position, Quaternion.identity);
    }


    bool TouchHitsThis(Vector2 position)
    {
        if (has2D)
        {
            Vector3 world = ScreenToWorld(position);
            return Physics2D.OverlapPoint(world) == GetComponent<Collider2D>();
        }

        if (has3D)
        {
            Ray ray = cam.ScreenPointToRay(position);
            return Physics.Raycast(ray, out RaycastHit hit) && hit.collider == GetComponent<Collider>();
        }
        return true;
    }

    Vector3 ScreenToWorld(Vector2 position)
    {
        var screenPosition = new Vector3(position.x, position.y, screenZ);
        return cam.ScreenToWorldPoint(screenPosition);
    }
}
