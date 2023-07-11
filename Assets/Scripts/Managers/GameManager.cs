using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject player;

    [SerializeField] private GameObject playerInventoryUI;
    [SerializeField] private GameObject containerInventoryUI;

    private void Awake()
    {
        //Implement the singleton design
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        ResumeTime();
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void SetPlayer(GameObject newPlayerObject)
    {
        player = newPlayerObject;
    }

    public GameObject GetPlayerInventoryUI()
    {
        return playerInventoryUI;
    }

    public GameObject GetContainerInventoryUI()
    {
        return containerInventoryUI;
    }

    public void PauseTime()
    {
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
