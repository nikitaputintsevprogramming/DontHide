using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreyGirlCome : MonoBehaviour
{
    //public static ProClickMove Instance { get; set; }    

    public Vector2 speed = new Vector2(5, 10);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;

    public GameObject lockerX;
    public GameObject tableX;
    public GameObject bedX;
    public GameObject wardrobeX;

    public Animator animator;

    CameraController cameraControl;

    float posLocker;
    float posTable;
    float posBed;
    float posWardrobe;
    
    float[] myArr = new float[4];
    private float TimeIsSeek;
    private bool circle = true;

    public Text textFind;
    public bool CameraChange = false;
    public bool NextText = false;


        // Start is called before the first frame update
    void Start()
    {        
        cameraControl = GameObject.Find("MainCamera").GetComponent<CameraController>();

        posLocker = lockerX.GetComponent<Transform>().position.x;
        posTable = tableX.GetComponent<Transform>().position.x;
        posBed = bedX.GetComponent<Transform>().position.x;
        posWardrobe = wardrobeX.GetComponent<Transform>().position.x;        

        myArr[0] = posLocker;
        myArr[1] = posTable;
        myArr[2] = posBed;
        myArr[3] = posWardrobe;

        TimeIsSeek = myArr[Random.Range(0, myArr.Length)];
        //Debug.Log(TimeIsSeek);

    }

     void Update()
     {

         movement = new Vector2( speed.x * direction.x, speed.y * direction.y );
         textFind.transform.position = new Vector3(transform.position.x, transform.position.y + 4, -5f);

    }

    void FixedUpdate()
    {        

        if (gameObject.transform.position.x - 3 >= TimeIsSeek && ProClickMove.Instance.isReady())
        {            

            CameraChange = true;

            animator.SetInteger("stateGrey", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Rigidbody2D>().velocity = movement;           

            if (gameObject.transform.position.x + 3 > TimeIsSeek && gameObject.transform.position.x - 4 < TimeIsSeek)
            {
                animator.SetInteger("stateGrey", 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

                NextText = true;

                if (circle)
                {
                    if (ProClickMove.Instance.locker && myArr[0] == TimeIsSeek)
                        textFind.text = "U are in the locker! Come on!";
                    else if (ProClickMove.Instance.table && myArr[1] == TimeIsSeek)
                        textFind.text = "U are under the table! Come on!";
                    else if (ProClickMove.Instance.bed && myArr[2] == TimeIsSeek)
                        textFind.text = "U are under the bed! Come on!";
                    else if (ProClickMove.Instance.wardrobe && myArr[3] == TimeIsSeek)
                        textFind.text = "U are in the wardrobe, Come on!";
                    else
                        textFind.text = "Hmm... I will find you...";

                    circle = false;
                }
                
                if (gameObject.transform.position.x - 4.5 <= TimeIsSeek)
                {
                    StartCoroutine(Example());
                }

            }

            
            
            

        }
    
    }

    IEnumerator Example()
    {        
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Room");
    }


}





