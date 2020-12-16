using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerPresenter : MonoBehaviour
{

    
    public PlayerModel model = new PlayerModel();
    [SerializeField] private PlayerView view;

    

    // Start is called before the first frame update
    void Start()
    {
        model.IsTurn
            .Subscribe(_ => view.ChangeDirection());
    
        view.IsTurn
            .Subscribe(a => {
                model.IsTurn.Value = a;
                Debug.Log(a);
            }); 

        view.coinCount
            .Subscribe(b => {
                model.coinCount.Value = b;
                Debug.Log("コインの数は" + b);
            });

        view.playerHP
            .Subscribe(c => {
                //.SkipLatestValueOnSubscribe();
                model.playerHP.Value = c;
                Debug.Log("HPは" + c);
                model.CalcPlayerHP();
            });

        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(model.MOVELEFT_KEY))
            .Subscribe(_ => {
                view.Move(model.speed * -1);
                model.ChangeDirection(false);
            });

        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(model.MOVERIGHT_KEY))
            .Subscribe(_ => {
                view.Move(model.speed);
                model.ChangeDirection(true);
            });
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyUp(model.MOVELEFT_KEY)||Input.GetKeyUp(model.MOVERIGHT_KEY))
            .Subscribe(_ => {
                view.MoveStop();
            });
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(model.JUMP_KEY))
            .Subscribe(_ => {
                Debug.Log("JUMP");
                view.Junp();
            });
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(model.THROWSWORD_KEY))
            .Subscribe(_ => {
                view.ThrowSword();
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
