using UnityEngine;

public class malvadosManager : MonoBehaviour
{
    private float tempoDecorrido;
    public scriptmalvado inimigoPequenoPrefab;
    public scriptmalvado inimigoGrandePrefab;

    void Start()
    {
        this.tempoDecorrido = 0;
    }

    
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

            scriptmalvado prefabInimigo;
            float chanceSpawn = Random.Range(0f, 100f);

            if (chanceSpawn <= 25)
            {
                prefabInimigo = this.inimigoGrandePrefab;
            }
            else
            {
                prefabInimigo = this.inimigoPequenoPrefab;
            }

                Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
        }

    }
}
