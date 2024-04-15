using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float verticalInput;
    public float lives = 3;
    public float speed = 25.0f;
    public float xRange = 75;
    public float zRange = 48;

    private Transform objectTransform;

    void Start()
    {
        objectTransform = gameObject.transform;
        Debug.Log(objectTransform.rotation);
    }

    // Update is called once per frame  
    void Update()
    {
        if (objectTransform.rotation != Quaternion.Euler(-90f, 0f, 0f))
        {
            objectTransform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        if(transform.rotation != Quaternion.Euler(-90f, 0f, 0f)){
             objectTransform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < -zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if(transform.position.z > zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if(transform.position.y != 0.5f){
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.down * verticalInput * Time.deltaTime * speed);

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 90f, 0f);
        }
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(-90f, -90f, 0f);
        }
        if (verticalInput > 0)
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        if (verticalInput < 0)
        {
            transform.rotation = Quaternion.Euler(-90f, 180f, 0f);
        }
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Fish")
        {   
            transform.position = new Vector3(0, 0.5f, 0);
            if(lives == 0){
                Destroy(gameObject);
                SceneManager.LoadScene("Game Over");

            }else{
                
                lives--;
                Debug.Log("Lives remaining: " + lives);
            }
            
        }
        else if(other.gameObject.tag == "Trash"){
            FishScript.level++;
            Destroy(other.gameObject);
        }

    }
}