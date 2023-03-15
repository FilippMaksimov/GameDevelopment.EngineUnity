using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //����� OnTriggerEnter(Collision Other) �������� ������, ����� ���������� ����������� � ��������,
    //������� �������� ��� Trigger.� ����� ������ ����� ��������-��������� ����� ��������� ��������� Plane.��� ������������ ��������
    //����������� ������������ Particle System (em.enabled = true), � ���� ���������� ���������(rend.enabled = false)
    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}
