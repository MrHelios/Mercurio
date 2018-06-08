using UnityEngine;

public class cooldownGlobal : MonoBehaviour
{
    public cooldown cd;

    void Start()
    {
        cd = new cooldown();
        cd.setCooldown(0.5f);
        cd.setUltimaVez(Time.time);
    }
}
