using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject panel;
    public Text panelText;

    public static bool changeLevel;
    public int Level;

    bool countEnemy;




    GameObject[] amountEnemy;
    int amountEnemyNEW;

    bool SpawnON = true;
	public float SpeedEnemy;

    GameObject EnemyInvoke;
    //bool invokeEmeny;


    public GameObject enemyJustMove;
    public GameObject enemyJustMoveDmg;
    public GameObject JustMoveAndShot;
    public GameObject JustMoveAndShotDmg;

    private int currentLevel;


    private float timePanel;
    void Start()
	{
        Level = 1;
        panelText.text = "";
        currentLevel = Level;
    }
    void Update()
    {
        ChangeEnemy();

        amountEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log("quantidade de inimigos: " + (amountEnemy.Length));
        //Debug.Log(amountEnemy.Length);

        //Debug.Log("contando inimigo");
        if (amountEnemy.Length == 0)
        {
           
           // Debug.Log("inicou o painel");

            panel.SetActive(true);
                panelText.text = "Stage " + Level;
                currentLevel = Level;
            
            

            timePanel += Time.deltaTime;
            if (timePanel >= 2)
            {

                //panel.SetActive(false);
                panelText.text = "";

                //Debug.LogWarning("desativou o painel");
                Debug.LogError("Saiu do painel");
                timePanel = 0;
                ChangeEnemy();
                Level += 1;
                currentLevel = Level;
                InvokeRepeating("Generate", 0, SpeedEnemy);
                Generate(Level);
                panel.SetActive(false);

            }


        }

        //Debug.Log(timePanel);


    }
    
  
    void JustInvoke()
    {
        Debug.LogWarning("invocou o inimigo");

        

    }


    void ChangeEnemy()
    {
        if (Level == 1)
        {
            EnemyInvoke = enemyJustMove;
        }
        if (Level == 2)
        {
            EnemyInvoke = enemyJustMoveDmg;
        }
        if (Level == 3)
        {
            EnemyInvoke = JustMoveAndShot;
        }
        if (Level == 4)
        {
            EnemyInvoke = JustMoveAndShotDmg;
        }
    }
    void Generate(int h)
	{
        for (int i = 0; i< h; i++)
        {

            int x = Random.Range(0, Camera.main.pixelWidth);
            int y = Random.Range(0, Camera.main.pixelHeight);

            Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            Target.z = 0;
            Instantiate(EnemyInvoke, Target, Quaternion.identity);


        }
    }
	
}
