using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Runtime
    PlayerControls pControls;

    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public bool gameOver = false;

    public int meteorCount = 0;


    private void Awake()
    {
        pControls = new PlayerControls();

        pControls.Options.Restart.started += ctx => Restart();
    }

    void Start()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        GameObject.Find("CameraController").GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    public void MeteorCounter()
    {
        meteorCount++;

        if(meteorCount == 5)
        {
            BigMeteor();
        }
    }

    public void OnGameOver()
    {
        gameOver = true;

        CancelInvoke();
    }

    void Restart()
    {
        if(gameOver)
            SceneManager.LoadScene("Week5Lab");
    }

    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        CameraController.instance.ZoomOut();
    }

    private void OnEnable()
    {
        pControls.Enable();
    }

    private void OnDisable()
    {
        pControls.Disable();
    }
}
