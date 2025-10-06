using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class malvadosManager : MonoBehaviour
{
    private float tempoDecorrido;
    public scriptmalvado inimigoPequenoPrefab;
    public scriptmalvado inimigoGrandePrefab;
    public scriptmalvado inimigoBoss;

    private bool bossSpawnado = false;

    [SerializeField] private string vitoria;

    public void Start()
    {
        tempoDecorrido = 0;
    }

    public void Update()
    {
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido >= 1f)
        {
            tempoDecorrido = 0;

            Vector2 posicaoMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            float posicaoX = Random.Range(posicaoMin.x, posicaoMax.x);
            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMax.y);


            scriptmalvado prefabInimigo;
            float chanceSpawn = Random.Range(0f, 100f);

            if (chanceSpawn <= 25)
            {
                prefabInimigo = inimigoGrandePrefab;
            }
            else
            {
                prefabInimigo = inimigoPequenoPrefab;
            }

            Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);


            if (pontuacao.Pontos >= 35)
            {
                prefabInimigo = inimigoBoss;

                if (!bossSpawnado)
                {
                    Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
                    bossSpawnado = true;
                }

                return;
            }

            
        }

        
    }
    public void TelaDeVitoria()
    {
        SceneManager.LoadScene(vitoria);
    }

}