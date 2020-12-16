using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class PlayerModel
{
    public KeyCode JUMP_KEY= KeyCode.Z;
    public KeyCode MOVELEFT_KEY= KeyCode.LeftArrow;
    public KeyCode MOVERIGHT_KEY= KeyCode.RightArrow;
    public KeyCode THROWSWORD_KEY = KeyCode.X;
    private float x;
    public float speed = 4;
    public ReactiveProperty<bool> IsTurn = new ReactiveProperty<bool>(false);
    public ReactiveProperty<int> coinCount = new ReactiveProperty<int>();
    public ReactiveProperty<int> playerHP =  new ReactiveProperty<int>();

    
    public PlayerModel(){
        // this.playerHP
        //     .Subscribe(_ => {
        //         Debug.Log("modelのHPが変わった");
        //         this.CalcPlayerHP();
        //     });
    }
    public void ChangeDirection(bool direction){
            IsTurn.Value = direction;
    }

    public void CalcCoin(int coin){
        coinCount.Value = coin;
    }

    public void CalcPlayerHP(){
        Debug.Log("HPは" + playerHP.Value);
        if(playerHP.Value <= 0){
            Debug.Log("GameOverをロード");
            SceneManager.LoadScene("GameOver");
        }
    }

}
