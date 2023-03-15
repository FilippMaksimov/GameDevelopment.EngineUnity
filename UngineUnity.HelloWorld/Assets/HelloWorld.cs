using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public GameObject obj;
    public GameObject figure;
    public GameObject figure2;
    // Start is called before the first frame update
    void Start()
    {
        //print("Hello World");
        Debug.Log("Goodbye World");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HELLO WORLD");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(obj);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Destroy(figure);
        }
        if (Input.GetKeyUp (KeyCode.R))
        {
            Destroy(figure2);
        }
    }
}
