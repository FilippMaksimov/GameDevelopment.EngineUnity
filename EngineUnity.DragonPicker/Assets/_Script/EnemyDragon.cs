using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject dragonEggPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;
    // Start is called before the first frame update

    //������� Invoke � ������ Start() ���� �������� �������, �������� ������ ����� ��������� ����� ������.� ������ ������ � ���������� ������� DropEgg(),
    //� ���������� 2f, �.�.� ��������� 2 ������� ����� ������ ����� �������
    void Start()
    {
        Invoke("DropEgg", 2f);
    }

    //������� DropEgg() ������� ��������� GameObject � ������ dragonEggPrefab � ����������� ��� ���������� egg.����� ���������� ��������� egg,
    //� ������� �������� ���� ���� ����� ����� ��������� �������, ������ timeBetweenEggDrops
    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = myVector + transform.position;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos � ��� ��������� ���������� ��� �������� ������� �������
        Vector3 pos = transform.position;
        //x ������������� �� ������������ �������� � ���������� ��������� Time.deltaTime
        pos.x += speed * Time.deltaTime;
        //��������� �������� pos ������������ ������� � transform.position
        transform.position = pos;

        //���� �������� pos.x ��������� ������ �������� leftRightDistance � ���������� speed ����� ������������� ��������(�������� ������)
        if (pos.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        //���� �������� pos.x ��������� ������ �������� leftRightDistance � ���������� speed ������������� ������������� ��������(�������� �����)
        else if (pos.x > leftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }
}