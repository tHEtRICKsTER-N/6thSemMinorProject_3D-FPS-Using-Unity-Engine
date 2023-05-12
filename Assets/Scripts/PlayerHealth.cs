using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public bool gameOver = false;
    
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private Text _healthText;


    void Start()
    {
        _playerPanel = GameObject.FindGameObjectWithTag("playercanvas");
        _healthText = GameObject.Find("Health_txt").GetComponent<Text>();
        currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pausePanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                _pausePanel.SetActive(false);
                _playerPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                _playerPanel.SetActive(false);
                _pausePanel.SetActive(true);
            }
        }

        if (gameOver)
        {
             _playerPanel.SetActive(false);
            _gameOverPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if(Time.timeScale >= 0)
                Time.timeScale -= 0.75f * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        _healthText.text = currentHealth.ToString();
        currentHealth -= damage;
        Debug.Log("Current Health :" + currentHealth);

        if(currentHealth <= 0)
        {
            //die
            gameOver = true;
            Debug.Log("DIED");
        }
    }
}
