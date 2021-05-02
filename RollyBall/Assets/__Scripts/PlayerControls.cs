using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControls : MonoBehaviour   
{
  
  //declare private variables uses
  private Rigidbody rigidbody;
  private int count;
 
  
  //declare public variables used, these can be accessed in the inspecter 
  public GameObject myFirstPrefab;
  public GameObject mySecondPrefab;
  public GameObject myThirdPrefab;
  public float speed;
  public Text countText;
  public Text winText; 
  public float pushForce;
              
  void Start(){ // called on the first frame that the script is active

        //initalize variables  
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        pushForce = 10;
    

        //create copies of Prize prefab and make it spawn at different locations
        Instantiate(myFirstPrefab, new Vector3(-6,1,1), Quaternion.identity);
        Instantiate(myFirstPrefab, new Vector3(-3,1,-4), Quaternion.identity);
        Instantiate(myFirstPrefab, new Vector3(4,1,-4), Quaternion.identity);
        Instantiate(myFirstPrefab, new Vector3(6,1,2), Quaternion.identity);
        Instantiate(myFirstPrefab, new Vector3(0,1,4), Quaternion.identity);

        //create copies of Prize2 prefab and make it spawn at different locations
        Instantiate(mySecondPrefab, new Vector3(-7,1,-7), Quaternion.identity);
        Instantiate(mySecondPrefab, new Vector3(7,1,7), Quaternion.identity);
        Instantiate(mySecondPrefab, new Vector3(-7,1,7), Quaternion.identity);
        Instantiate(mySecondPrefab, new Vector3(7,1,-7), Quaternion.identity);

        //create copies of Prize3 prefab and make it spawn at different locations
        Instantiate(myThirdPrefab, new Vector3(-14,1,0), Quaternion.identity);
        Instantiate(myThirdPrefab, new Vector3(14,1,0), Quaternion.identity);
     
  }

  void FixedUpdate ()// called before performing any physics
  
  { 

      float moveHorizontal = Input.GetAxis("Horizontal");//record input from the keyboard and store them 
      float moveVertical = Input.GetAxis("Vertical");//record input from the keyboard and store them 

      Vector3 move = new Vector3(moveHorizontal,0.0f,moveVertical);//put input in vector allowing the player to move
      
      rigidbody.AddForce(move * speed);// multiply movement by speed to create the feel of a force acting on the ball


  }

  void OnTriggerEnter(Collider other)
 
  {
     //add one point to score if the player hits a pickup with the Prize tag
     if (other.gameObject.CompareTag("Prize")){
         other.gameObject.SetActive(false);
         count = count + 1;
         SetCountText();

     }
    //add two points to score if the player hits a pickup with the Prize2 tag
      if (other.gameObject.CompareTag("Prize2")){
         other.gameObject.SetActive(false);
         count = count + 2;
         SetCountText();

     }
     
     //add three points to score if the player hits a pickup with the Prize2 tag
      if(other.gameObject.CompareTag("Prize3")){
         other.gameObject.SetActive(false);
         count = count + 3;
         SetCountText();

     }
  
    //when all the pickups have been collected, display you win, pause game and call restart methof after 3 seconds 
    if( count >= 19){
        winText.text = "You Win!";
        Invoke("Restart", 3);
    }

  }

//set on screen score to be the count in a string
  void SetCountText (){
         
         countText.text = "Score: " + count.ToString();
      
    }
        
  
  //Restart game by reloading game scene 
  public void Restart()
     {
        SceneManager.LoadScene("Minigame");
           
     }
   
}
