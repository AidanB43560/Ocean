using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public static int level = 0;
    private int movementDirection = 1;
    public int enemyCount;
    

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        MoveFish();

        if (transform.position.x < -80 && movementDirection == -1)
        {
            movementDirection = 1;
            SetRotation(90, 0, 180);
        }
        else if (transform.position.x > 80 && movementDirection == 1)
        {
            movementDirection = -1;
            SetRotation(90, 0, 0);
        }
        
    }

    void MoveFish()
    {
        transform.Translate(Vector3.left * Time.deltaTime * level);
    }

    void SetRotation(float x, float y, float z)
    {
        transform.rotation = Quaternion.Euler(x, y, z);
    }
}
