public class vida
{
    private int vida_act, vida_max;
    private bool estamuerto;

    public vida(int v)
    {
        vida_act = vida_max = v;
        estamuerto = false;
    }   

    public void setVidaMax(int v)
    {
        vida_max = v;
        if (vida_act > vida_max)
            vida_act = vida_max;
    }

    public void ganaVida()
    {
        vida_act++;
        if (vida_max < vida_act)
            vida_act = vida_max;
    }

    public void restaurar_maxima_vida()
    {
        vida_act = vida_max;
        estamuerto = false;
    }

    public void pierdeVida()
    {
        vida_act--;
        if (vida_act == 0)
            muerte();
    }

    public int getVidaMax()
    {
        return vida_max;
    }

    public int getVidaAct()
    {
        return vida_act;
    }

    public bool estaMuerto()
    {
        return estamuerto;
    }

    public void muerte()
    {
        vida_act = 0;
        estamuerto = true;
    }
}
