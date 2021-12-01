using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeGridManager : MonoBehaviour
{

    public GameObject nodePrefab;
    public GameObject wallManager;
    public GameObject entranceManager;
    public GameObject exitManager;
    public GameObject itemNodeManager;
    Node activeEntranceNode;
    Node defaultEntranceNode;

    Node[,] nodeGrid;
    GameObject[] walls;
    GameObject[] entrances;
    GameObject[] exits;
    GameObject[] items;
    public int gridX = 16;
    public int gridY = 16;
    int maxX;
    int maxY;
    public float scale = 0.32f;

    private void Start()
    {
      
        GetWalls();
        GetEntrances();
        GetExits();
        GetItems();
        InitGrid();

        activeEntranceNode = GetNode(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "X"), PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Y"));
        if (activeEntranceNode.x == 0 && activeEntranceNode.y == 0)
        {
            activeEntranceNode = defaultEntranceNode;
        }

        PlayerController.singleton.Init(this, activeEntranceNode);
        PlayerController.singleton.playerObj.transform.position = new Vector2 (activeEntranceNode.x, activeEntranceNode.y); 
        PlayerController.singleton.cameraMover.Tick(activeEntranceNode.worldPosition);
    }
    void GetWalls()
   {
        walls = new GameObject[wallManager.transform.childCount];
        for (int i = 0; i < wallManager.transform.childCount; i++)
        {
            walls[i] = wallManager.transform.GetChild(i).gameObject;
        }
   }
    void GetEntrances()
    {
        entrances = new GameObject[entranceManager.transform.childCount];
        for (int i = 0; i < entranceManager.transform.childCount; i++)
        {
            entrances[i] = entranceManager.transform.GetChild(i).gameObject;
        }
    }
    void GetExits()
    {
        exits = new GameObject[exitManager.transform.childCount];
        for (int i = 0; i < exitManager.transform.childCount; i++)
        {
            exits[i] = exitManager.transform.GetChild(i).gameObject;
        }
    }
    void GetItems()
    {
        items = new GameObject[itemNodeManager.transform.childCount];
        for (int i = 0; i < itemNodeManager.transform.childCount; i++)
        {
           items[i] = itemNodeManager.transform.GetChild(i).gameObject;
        }
    }
    void InitGrid()
    {

        nodeGrid = new Node[gridX, gridY];
        maxX = gridX;
        maxY = gridY;


            for (int x = 0; x <= gridX - 1; x++)
            {
                for (int y = 0; y <= gridY - 1; y++)
                {
                    Node n = nodeGrid[x, y];
                    if (n == null)
                    {
                        n = CreateAt(x, y);

                        nodeGrid[x, y] = n;
                    }

                }
            }
      
        foreach (GameObject w in walls)
        {
            Vector2 wallPos = new Vector2(w.transform.position.x, w.transform.position.y);
            Node n = nodeGrid[Mathf.RoundToInt(wallPos.x), Mathf.RoundToInt(wallPos.y)];
            n.isWall = true;

        }

        foreach (GameObject e in entrances)
        {
            Vector2 entrancePos = new Vector2(e.transform.position.x, e.transform.position.y);
            Node n = nodeGrid[Mathf.RoundToInt(entrancePos.x), Mathf.RoundToInt(entrancePos.y)];
            n.isEntrance = true;
            Entrance ee = e.GetComponent<Entrance>();  
            if (ee.isActive == true)
            {
               defaultEntranceNode = n;
            }
        }

        foreach (GameObject e in exits)
        {
            Vector2 exitPos = new Vector2(e.transform.position.x, e.transform.position.y);
            Node n = nodeGrid[Mathf.RoundToInt(exitPos.x), Mathf.RoundToInt(exitPos.y)];
            n.isExit = true;
            Exit ee = e.GetComponent<Exit>();
            n.exitScene = ee.GetExitScene();
        }

        foreach (GameObject i in items)
        {
            Vector2 itemPos = new Vector2(i.transform.position.x, i.transform.position.y);
            Node n = nodeGrid[Mathf.RoundToInt(itemPos.x), Mathf.RoundToInt(itemPos.y)];
            n.item = i.GetComponent<ItemNode>().item;
        }

    }
    public Node GetNode(int x, int y, bool clamp = false)
    {
        if (x < 0 || x > maxX || y < 0 || y > maxY)
        {
            if (!clamp)
            {
                return null;
            }
            else
            {
                if (x < 0)
                    x = 0;
                if (x > maxX)
                    x = maxX;
                if (y < 0)
                    y = 0;
                if (y > maxY)
                    y = maxY;

            }

        }

        return nodeGrid[x, y];
    }
    Node CreateAt(int x, int y)
    {
        Node n = nodeGrid[x, y];
        if (n == null)
        {
            n = new Node();
            n.x = x;
            n.y = y;

            GameObject go = Instantiate(nodePrefab);
            Vector3 tp = Vector3.zero;
            NodeReferences nr = go.GetComponent<NodeReferences>();
            n.nodeReferences = nr;

            tp.x = x * scale;
            tp.y = y * scale;
            tp.z = y;

            n.worldPosition = tp;

            go.transform.position = tp;
            go.transform.parent = transform;
            nodeGrid[x, y] = n;

        }

        return n;
    }
}
