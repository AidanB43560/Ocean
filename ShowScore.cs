using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text change;
    
    // Update is called once per frame
    void Update()
    {
        change.text = "Score: " + FishScript.level.ToString();
    }
}
