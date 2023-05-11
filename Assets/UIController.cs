using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject controlPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPlayPanel()
    {
        controlPanel.SetActive(false);
        playPanel.SetActive(true);
    }
}
