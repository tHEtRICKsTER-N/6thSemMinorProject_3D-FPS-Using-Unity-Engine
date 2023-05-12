using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    #region OBJ

    public static EnemyCounter obj;

    private void Awake()
    {
        obj = this;
    }

    #endregion

    public int enemyCount;   //45 enemies in total

    void Update()
    {
        if (enemyCount <= 0)
        {
            if (Time.timeScale >= 0)
                Time.timeScale -= 0.75f * Time.deltaTime;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
