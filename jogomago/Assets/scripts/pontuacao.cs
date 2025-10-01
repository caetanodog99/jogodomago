using UnityEngine;

public static class pontuacao
{
    private static int pontos;


    public static int Pontos
    { 
        get
        { 
            return pontos; 
        } 
        
        set 
        { 
            pontos = value;
            if (pontos < 0)
            {
                pontos = 0;
            }
            
        }
    }
   


}
