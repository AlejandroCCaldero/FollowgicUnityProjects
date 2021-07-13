using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject cup;
    public GameObject ball;
    public Transform ballApperancePosition;
    public CupsMovement movements;
    private GameObject ballInst;
    public Button exit;

    void Start () {
		Button btn = exit.GetComponent<Button>();
		exit.onClick.AddListener(Cerrar);
	}

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        cup.transform.Translate(Vector3.back * 7.5f);
        Instantiate(ball, ballApperancePosition.position, ballApperancePosition.rotation);
        Invoke("Restart",2f);
    }

    public void LevelUp()
    {
        cup.transform.Translate(Vector3.back * 7.5f);
        ballInst = Instantiate(ball, ballApperancePosition.position, ballApperancePosition.rotation);
        Invoke("Continue", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Continue()
    {
        Destroy(ballInst);
        cup.transform.Translate(Vector3.forward * 7.5f);
        movements.speed = movements.speed + 5;
        movements.cnt = 0;
        movements.finished = false;
    }

    void Cerrar()
    {
        Application.Quit();
    }
}
