using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    
    private Game game;
    private float winDelay = 1.0f;
    private GameObject stone;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        game.SetPosOnTarget((stone != null ? stone.transform.position : Vector3.positiveInfinity));
    }

    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Tag " + other.tag);
        
        if (other.gameObject.name == "Pierre" || other.tag == "Stone")
        {
            if (stone == null)
            {
                game.EnterTarget();
                stone = other.gameObject;
            }
            Debug.Log("Stone hit the target !");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Pierre" || other.tag == "Stone")
        {
            if (stone == null){
                stone = other.gameObject;
                game.EnterTarget();
            }

            if (stone.GetComponent<Rigidbody>().velocity.magnitude < 0.1){
                //EndGame();
                StartCoroutine(EndGame());
            }


            Debug.Log("Stone still hit the target !");
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name == "Pierre" || other.tag == "Stone")
        {
            game.ExitTarget();
            stone = null;
            Debug.Log("Stone exited the target !");
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(winDelay);

        if (game.OnTarget() && stone != null && stone.GetComponent<Rigidbody>().velocity.magnitude < 0.1)
        {
            game.ActivateMenu();
            game.CalcScore(stone.transform.position);
        }
    }

}
