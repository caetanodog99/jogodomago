using UnityEngine;

public class barraDeVida : MonoBehaviour
{
    public GameObject[] barrasverdes;

    public void ExibirVida(int vidas)
    {
        for(int i = 0; i < this.barrasverdes.Length; i++)
        {
            if (i < vidas)
            {
                this.barrasverdes[i].SetActive(true);    
            }
            else
            {
                this.barrasverdes[i].SetActive(false);
            }
        }
    }
}
