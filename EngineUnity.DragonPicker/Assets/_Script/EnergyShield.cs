using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyShield : MonoBehaviour
{
    public Text scoreGT;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        //For smartphones
        if (Input.touchSupported)
        {
            Touch touch = new Touch();
            Vector3 touchPos2D = touch.position;
            touchPos2D.z = -Camera.main.transform.position.z;
            Vector3 touchPos3D = Camera.main.ScreenToWorldPoint(touchPos2D);
            pos.x = touchPos3D.x;
            this.transform.position = pos;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "DragonEgg")
        {
            Destroy(collided);
        }
        int score = int.Parse(scoreGT.text);
        score += 1;
        scoreGT.text= score.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
