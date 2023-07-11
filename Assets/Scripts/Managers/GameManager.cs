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

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The player GameObject</returns>
    public GameObject GetPlayer()
    {
        return player;
    }

    /// <summary>
    /// Sets a new player GameObject
    /// </summary>
    /// <param name="newPlayerObject"></param>
    public void SetPlayer(GameObject newPlayerObject)
    {
        player = newPlayerObject;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Player inventory UI</returns>
    public GameObject GetPlayerInventoryUI()
    {
        return playerInventoryUI;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Container inventory UI</returns>
    public GameObject GetContainerInventoryUI()
    {
        return containerInventoryUI;
    }

    /// <summary>
    /// Sets time scale to zero and enables cursor
    /// </summary>
    public void PauseTime()
    {
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Sets time scale to 1 and disables cursor
    /// </summary>
    public void ResumeTime()
    {
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
