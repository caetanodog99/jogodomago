using UnityEngine;

public class malvadosManager : MonoBehaviour
{
    private float tempoDecorrido;
    public scriptmalvado inimigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.tempoDecorrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.tempoDecorrido += Time.deltaTime;
        if (this.tempoDecorrido >= 1f)
        {
            this.tempoDecorrido = 0;
            Vector2 posicaoMax = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));
            Vector2 posicaoMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            float posicaoX = Random.Range(posicaoMin.x, posicaoMax.x);  

            Vector2 posicaoInimigo = new Vector2 (posicaoX, posicaoMax.y);
            Instantiate(this.inimigo, posicaoInimigo, Quaternion.identity);
        }

    }
}
