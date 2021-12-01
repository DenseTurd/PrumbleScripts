using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float scale = 0.32f;
    public Transform playerObj;
    public CameraMover cameraMover;
    NodeGridManager nodeGridManager;
    Animator anim;

    Vector3 facingPosition;

    Node curNode;
    Node targetNode;

    public bool isLerping;

    bool mirror;

    bool up;
    bool down;
    bool left;
    bool right;
    string _up = "Up";
    string _down = "Down";
    string _left = "Left";
    string _right = "Right";

    public void Start()
    {
        anim = playerObj.GetComponent<Animator>();
        GameInfo.CurrentWorldScene = SceneManager.GetActiveScene().name;
    }
    public void Init(NodeGridManager g, Node startingNode)
    {
        nodeGridManager = g;
        curNode = startingNode;
        cameraMover.Init();
        cameraMover.Tick(playerObj.position);
        anim = playerObj.GetComponent<Animator>();
        

    }
    private void Update()
    {

        Vector3 targetPosition = Vector3.zero;
        if (isLerping)
        {
            LerpToPos();
            
            return;
        }

        GetInput();
       

        if (up)
        {

            targetPosition.y = 1;
            PathFind(targetPosition);
            AnimateMovement(targetPosition);
            return;
        }
        if (down)
        {
            targetPosition.y = -1;
            PathFind(targetPosition);
            AnimateMovement(targetPosition);
            return;
        }
        if (left)
        {
           // mirror = true;
            targetPosition.x = -1;
            PathFind(targetPosition);
            AnimateMovement(targetPosition);
            return;
        }
        if (right)
        {
           // mirror = false;
            targetPosition.x = 1;
            PathFind(targetPosition);
            AnimateMovement(targetPosition);
            return;
        }
        if(!up || !down || !left || !right)
        {
            AnimateMovement(targetPosition);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    void GetInput()
    {
        up = Input.GetButton(_up);
        down = Input.GetButton(_down);
        left = Input.GetButton(_left);
        right = Input.GetButton(_right);

    } 
    void PathFind(Vector3 tp)
    {
        if (nodeGridManager != null)
        {


            int x = Mathf.RoundToInt(tp.x);
            int y = Mathf.RoundToInt(tp.y);

            Node n = nodeGridManager.GetNode(curNode.x + x, curNode.y + y);
            if (n == null)
            {
                return;
            }
            if (n.isWall)
            {
                return;
            }

            targetNode = n;
            isLerping = true;

            if (n.isExit)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "X", Mathf.RoundToInt(curNode.worldPosition.x));
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Y", Mathf.RoundToInt(curNode.worldPosition.y));
                ChangeScene(n.exitScene);
            }
        }

    }

    bool initLerp;
    Vector3 targetP;
    Vector3 startP;
    float speedActual;
    public float baseSpeed = 5f;
    float t;

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LerpToPos()
    {
        if (!initLerp)
        {
            t = 0;
            startP = playerObj.position;
            targetP = targetNode.worldPosition;

            speedActual = baseSpeed;

            initLerp = true;
        }

        t += Time.deltaTime * speedActual;

        if (t > 1)
        {
            t = 1;
            isLerping = false;
            curNode = targetNode;
            initLerp = false;
        }

        float z;
        if (up)
        {
            z = targetNode.worldPosition.z - 1.5f;
        }
        else
        {
            z = targetNode.worldPosition.z - 0.5f;
        }

        
        Vector3 tp = Vector3.Lerp(startP, targetP, t);
        cameraMover.Tick(tp);

        tp.z = z;

        playerObj.position = tp;
    }
    void AnimateMovement(Vector3 targetPosition)
    {
        if (up || down || left || right)
        {
            anim.SetFloat("moveX", targetPosition.x);
            anim.SetFloat("moveY", targetPosition.y);
            anim.SetBool("walking", true);
            anim.SetFloat("lastMoveX", targetPosition.x);
            anim.SetFloat("lastMoveY", targetPosition.y);

            facingPosition.x = targetPosition.x;
            facingPosition.y = targetPosition.y;
        }
        else
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 0);
            if (!isLerping)
            {
                anim.SetBool("walking", false);
            }
        }

    }

    #region Singelton
    public static PlayerController singleton;
    private void Awake()
    {
        singleton = this;
    }
    #endregion

    public void Interact()
    {
        int x = Mathf.RoundToInt(facingPosition.x);
        int y = Mathf.RoundToInt(facingPosition.y);

        Node n = nodeGridManager.GetNode(curNode.x + x, curNode.y + y);
        if(n.item != null)
        {
            GameInfo.PlayerInventory.AddItem(n.item, 1);
            Debug.Log(n.item.description);
            n.item = null;
        }
    }
}
