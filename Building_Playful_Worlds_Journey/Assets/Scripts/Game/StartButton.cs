using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject panel;
    public Animator panelAnim;
    // Start is called before the first frame update
    void Start()
    {
        panelAnim = panel.GetComponent<Animator>();
    }

    public void Clicked()
    {
        panelAnim.SetTrigger("hasClicked");
    }


}
