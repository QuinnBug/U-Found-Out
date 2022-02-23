using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskElement : MonoBehaviour
{
    public GameObject canvasToLoad;

    // Start is called before the first frame update
    void Start()
    {
        canvasToLoad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        canvasToLoad.SetActive(true);
    }
}
