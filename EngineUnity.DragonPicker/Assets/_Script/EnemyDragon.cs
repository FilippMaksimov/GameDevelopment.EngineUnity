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

    //‘ункци€ Invoke в методе Start() выше вызывает функцию, заданную именем через указанное число секунд.¬ данном случае Ц вызываетс€ функци€ DropEgg(),
    //с параметром 2f, т.е.с ожиданием 2 секунды перед каждым новым вызовом
    void Start()
    {
        Invoke("DropEgg", 2f);
    }

    //‘ункци€ DropEgg() создает экземпл€р GameObject с именем dragonEggPrefab и присваивает его переменной egg.ƒалее измен€етс€ положение egg,
    //и функци€ вызывает саму себ€ снова через интервалы времени, равные timeBetweenEggDrops
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
        //Vector3 pos Ц это локальна€ переменна€ дл€ хранени€ текущий позиции
        Vector3 pos = transform.position;
        //x увеличиваетс€ на произведение скорости и временного интервала Time.deltaTime
        pos.x += speed * Time.deltaTime;
        //»зменение значени€ pos записываетс€ обратно в transform.position
        transform.position = pos;

        //если значение pos.x оказалось меньше значени€ leftRightDistance Ц переменна€ speed имеет положительное значение(движение вправо)
        if (pos.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        //если значение pos.x оказалось больше значени€ leftRightDistance Ц переменной speed присваиваетс€ отрицательное значение(движение влево)
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