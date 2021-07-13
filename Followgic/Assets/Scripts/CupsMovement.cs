using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupsMovement : MonoBehaviour
{
    public Transform[] positions;
    public Transform[] secondaryPositions;
    public Transform[] thirdPosition;
    public GameObject[] cups;
    private GameObject aux;
    private int rndPosition;
    private int rndCup;
    public int cnt;
    public Transform ballPosition;
    public GameObject ball;
    public bool finished;
    private bool firstTime;
    public AudioSource movementSound;
    private bool movementSoundPlaying;
    private bool movementDone;
    public int score;
    public float speed;
    private bool moving;

    void Start()
    {
        moving = true;
        score = 0;
        cnt = 0;
        speed = 10;
        firstTime = true;
        finished = false;
        movementSoundPlaying = false;
        movementDone = true;

        rndCup = Random.Range(0, 2);
        rndPosition = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstTime)
        {
            cups[0].transform.position = Vector3.MoveTowards(cups[0].transform.position, positions[0].position, 5 * Time.deltaTime);
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, ballPosition.position, 10 * Time.deltaTime);

            if(cups[0].transform.position.y == positions[0].position.y)
            {
                firstTime = false;
                ball.SetActive(false);
            }
        }
        if(!finished)
        {
            if(!firstTime)
            {
                if(!movementSoundPlaying)
                {
                    movementSound.Play();
                    movementSoundPlaying = true;
                }

                if(rndCup == 1 && rndPosition == 1)
                {
                    rndCup = 2;
                }

                if(movementDone)
                {
                    moving = true;
                    //Primero pasamos el vaso correspondiente al fondo
                    cups[rndCup].transform.position = Vector3.MoveTowards(cups[rndCup].transform.position, secondaryPositions[rndCup].position, speed * Time.deltaTime); 

                    //En segundo lugar, pasamos el vaso con el que se va a intercambiar al frente
                    cups[rndPosition].transform.position = Vector3.MoveTowards(cups[rndPosition].transform.position, thirdPosition[rndPosition].position, speed * Time.deltaTime);
                }

                if(cups[rndCup].transform.position.x == secondaryPositions[rndCup].position.x && cups[rndPosition].transform.position.x == thirdPosition[rndPosition].position.x)
                {
                    cups[rndCup].transform.position = Vector3.MoveTowards(cups[rndCup].transform.position, secondaryPositions[rndPosition].position, speed * 2 * Time.deltaTime);
                    cups[rndPosition].transform.position = Vector3.MoveTowards(cups[rndPosition].transform.position, thirdPosition[rndCup].position, speed * 2 * Time.deltaTime);
                }

                if(cups[rndCup].transform.position.z == secondaryPositions[rndPosition].position.z && cups[rndPosition].transform.position.z == thirdPosition[rndCup].position.z)
                {
                    //Debug.Log("Hello");
                    cups[rndCup].transform.position = Vector3.MoveTowards(cups[rndCup].transform.position, positions[rndPosition].position, speed * Time.deltaTime);
                    cups[rndPosition].transform.position = Vector3.MoveTowards(cups[rndPosition].transform.position, positions[rndCup].position, speed * Time.deltaTime);
                    movementDone = false;
                }

                if(cups[rndCup].transform.position.x == positions[rndPosition].position.x && cups[rndPosition].transform.position.x == positions[rndCup].position.x)
                {
                    aux = cups[rndCup];
                    cups[rndCup] = cups[rndPosition];
                    cups[rndPosition] = aux;
                    moving = false;

                    moveCups();
                }

                if(cnt == 5)
                {
                    finished = true;
                    movementSound.Stop();
                    movementSoundPlaying = false;
                }
            }
        }
    }

    private void moveCups()
    {
        rndCup = Random.Range(0, 2);
        rndPosition = Random.Range(1, 3);
        cnt++;
        movementDone = true;
    }

    public bool isMoving()
    {
        return this.moving;
    }
}
