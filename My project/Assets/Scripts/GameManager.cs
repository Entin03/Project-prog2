using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
/*      --VERSION 1.0--
    public static GameManager instance;
    private void Awake()
    {
       if  (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
      //  PlayerPrefs.DeleteAll();      //Törli a mentéseket 

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> toolsSprites;
    public List<int> xpTable;

    // References
    //public Player player;

    // Logic
    public int buza;
    public int exp;

    // Save state
 
    public void SaveState()
    {
        //PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
    }

       public void LoadState(Scene s, LoadSceneMode mode)
    {
        Debug.Log("LoadState");
    }
*/

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;



}    
   

      


     

   