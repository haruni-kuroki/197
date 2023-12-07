using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class SceneLoader : MonoBehaviour
{
  public string sceneName ="";
  public string prefecture ="";
  public static string selected_prefecture;
  // 0: Tokyo
  // 1: Gunma
  // 2: Aiti
  // 3: Hyogo
  static int[] visited_city = {0,0,0,0};
  
  void Start(){
    if(prefecture == "Tokyo" && visited_city[0] == 1){
      this.GetComponent<SpriteRenderer>().color = Color.white;
    }
    if(prefecture == "Gunma" && visited_city[1] == 1){
      this.GetComponent<SpriteRenderer>().color = Color.white;
    }
    if(prefecture == "Aiti" && visited_city[2] == 1){
      this.GetComponent<SpriteRenderer>().color = Color.white;
    }
    if(prefecture == "Hyogo" && visited_city[3] == 1){
      this.GetComponent<SpriteRenderer>().color = Color.white;
    }
  }
   // Start is called before the first frame update
   public void SceneChange()
    {

      if(prefecture == "Tanegashima"){
        if(visited_city.Sum() == 4){
          selected_prefecture = prefecture;
          SceneManager.LoadScene(sceneName);
        }
      }else {
        selected_prefecture = prefecture;
        if(prefecture == "Tokyo" && visited_city[0] == 0){
          visited_city[0] = 1;
          this.GetComponent<SpriteRenderer>().color = Color.white;
          SceneManager.LoadScene(sceneName);
        }
        if(prefecture == "Gunma" && visited_city[1] == 0){
          visited_city[1] = 1;
          this.GetComponent<SpriteRenderer>().color = Color.white;
         SceneManager.LoadScene(sceneName);
        }
        if(prefecture == "Aiti" && visited_city[2] == 0){
          visited_city[2] = 1;
          this.GetComponent<SpriteRenderer>().color = Color.white;
          SceneManager.LoadScene(sceneName);
        }
        if(prefecture == "Hyogo" && visited_city[3] == 0){
          visited_city[3] = 1;
          this.GetComponent<SpriteRenderer>().color = Color.white;
          SceneManager.LoadScene(sceneName);
        }
        if(prefecture == "Start"){
          SceneManager.LoadScene(sceneName);
        }
        if(prefecture == "End"){
          SceneManager.LoadScene(sceneName);
        }
      }
      // if(prefecture == "Tokyo") visited_city[0] = 1;
      // if(prefecture == "Gunma") visited_city[1] = 1;
      // if(prefecture == "Aiti")  visited_city[2] = 1;
      // if(prefecture == "Hyogo") visited_city[3] = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
