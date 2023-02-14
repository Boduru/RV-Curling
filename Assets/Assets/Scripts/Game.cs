using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject stone;
    private Rigidbody stoneRigidBody;
    public GameObject target;
    public GameObject halo;
    public GameObject player;
    public GameObject endLevelMenu;
    public Vector3 respawnLocation;
    public int ymin = int.MaxValue;
    public float targetFriction = 0.99f;
    public float initRotSpeed = 300.0f;
    public float haloRotationSpeed = 10.0f;

    public InputAction respawnAction;


    private bool onTarget = false;

    private Vector3 posOnTarget = Vector3.positiveInfinity;
    private int score = 0;
    private float targetRadius = 3.3f;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game Start");

        Init();

        // Input
        /*var respawnAction = new InputAction("respawn", binding: "/input/a/click");
        respawnAction.AddBinding("/input/b/click");
        respawnAction.AddBinding("/input/x/click");
        respawnAction.AddBinding("/input/y/click");*/

        respawnAction.Enable();

        respawnAction.started += ctx => RespawnStone();

        //SceneManager.activeSceneChanged += ChangedActiveScene;
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stone.transform.position.y < ymin)
        {
            //Debug.Log("Stone fell off the map");
            RespawnStone();
        }

        if (onTarget)
        {
            SlowStone();
        }

        /*if (onTarget)
        {
            SlowStone();
            //Debug.Log("Position on the target : " + score);
            //Debug.Log(stoneRigidBody.velocity.magnitude);

            if (stoneRigidBody.velocity.magnitude < 0.1)
            {
                score = CalcScore();
                //Debug.Log("You won !");
                //NextLevel();
                //endLevelMenu.SetActive(true);
                ActivateMenu();
            }
        }*/

        UpdateHalo(posOnTarget);


    }

    public void Init(){
        
        Debug.Log("Game is starting !");
        if (stone == null) stone = GameObject.Find("Pierre");
        if (target == null) target = GameObject.Find("Target");
        if (halo == null) halo = GameObject.Find("lightBeam");
        if (player == null) player = GameObject.Find("XR Origin");
        if (endLevelMenu == null) endLevelMenu = GameObject.Find("Signs");

        DeactivateMenu();

        respawnLocation = stone.transform.position;
        stoneRigidBody = stone.GetComponent<Rigidbody>();       

        if (ymin == int.MaxValue){
            // finding the lowest point in the scene
            GameObject[] objects = SceneManager.GetActiveScene().GetRootGameObjects();
            for (int i = 0; i < objects.Length; i++)
            {   
                Collider[] colliders = objects[i].GetComponentsInChildren<Collider>();
                for (int j = 0; j < colliders.Length; j++)
                {
                    int y = (int)colliders[j].bounds.min.y;
                    if (y < ymin) ymin = y;
                }
            }
            ymin--;
        }

        Debug.Log("ymin :" + ymin);
    }

    public void ActivateMenu(){
        for (int i = 0; i < endLevelMenu.transform.childCount; i++)
        {
            endLevelMenu.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void DeactivateMenu(){
        for (int i = 0; i < endLevelMenu.transform.childCount; i++)
        {
            endLevelMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ChangedActiveScene(Scene current, Scene next){
        if (current.name != "Lobby" || next.name != "Lobby"){
            Init();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Lobby"){
            Init();
        }
    }

    public void RespawnStone()
    {
        //Debug.Log("Respawning stone !");
        stone.transform.position = respawnLocation;
        stoneRigidBody.velocity = Vector3.zero;
        SpawnSpinAnimate();
    }

    void SpawnSpinAnimate()
    {
        float r = UnityEngine.Random.Range(1, 4);
        float side = UnityEngine.Random.Range(-1, 1);

        if (side == 0)
        {
            side = 1;
        }

        stoneRigidBody.AddRelativeTorque(0, r * side * initRotSpeed, 0);
    }

    public void UpdateHalo(Vector3 pos){
        Renderer Halorenderer = halo.GetComponent<Renderer>();
        float distanceToTarget = Vector3.Distance(target.transform.position, pos);
        
        Color green = Color.green;
        Color blue = Color.blue;
        Color white = Color.white;
        Color red = Color.red;

        float xScale = 3.5f;
        float zScale = 3.5f;
        Color color = green;
        if (onTarget){
            if (distanceToTarget < 1.0f){
                xScale = 1.0f;
                zScale = 1.0f;
                color = red;
            } 
            else if (distanceToTarget < 2.0f){
                xScale = 2.0f;
                zScale = 2.0f;
                color = white;
            } 
            else if  (distanceToTarget < 3.5f){
                color = blue;
            }
        }

        //Debug.Log("pos " + pos + "; distanceToTarget " + distanceToTarget + "; onTarget " + onTarget + "; Color " + color);

        halo.transform.localScale = new Vector3(xScale, 4.0f, zScale);
        halo.transform.Rotate(0, haloRotationSpeed * Time.deltaTime, 0);
        Halorenderer.material.SetColor("_Color", color);
    }

    public void SetRespawnLocation(Vector3 location)
    {
        respawnLocation = location;
    }

    public int CalcScore(Vector3 pos){
        score = (int)((targetRadius - Vector3.Distance(target.transform.position, pos)) * 1000);
        return score;
    }

    public void SetPosOnTarget(Vector3 pos){
        posOnTarget = pos;
    }

    public void SlowStone()
    {
        stoneRigidBody.velocity = stoneRigidBody.velocity * targetFriction;
    }

    public float DistanceToTarget()
    {
        return Vector3.Distance(target.transform.position, stone.transform.position);
    }

    public float DistanceToPlayer(){
        return Vector3.Distance(player.transform.position, stone.transform.position);
    }

    public void SetYMin(int y){
        ymin = y;
    }

    public bool OnTarget(){
        return onTarget;
    }

    public void EnterTarget(){
        onTarget = true;
        //Debug.Log("Stone entered the target !");
    }

    public void ExitTarget(){
        onTarget = false;
        //Debug.Log("Stone exited the target !");
    }
}
