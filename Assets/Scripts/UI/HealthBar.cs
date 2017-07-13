using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Scrollbar healthBar;
    
    void Update()
    {
        
        healthBar.size = StaticData.life / 100f;
    }
}
