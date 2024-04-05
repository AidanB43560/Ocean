using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput;
    private float verticalInput;
    public float lives = 3;
    public float speed = 25.0f;
    public float xRange = 75;
    public float zRange = 48;
    private Quaternion initialRotation;
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame  
    void Update()
    {
        
        if(transform.rotation != initialRotation){
            transform.rotation = Quaternion.identity;
            initialRotation = transform.rotation;
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
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Fish")
        {   
            transform.position = new Vector3(0, 0.5f, 0);
            if(lives == 0){
                Destroy(gameObject);
                Debug.Log("Score: " + FishScript.level);
                
                Debug.Log("Game Over");

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