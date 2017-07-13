using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {

    public Scrollbar healthBar;

    void Update()
    {

        healthBar.size = StaticData.armor / 100f;
    }
}
