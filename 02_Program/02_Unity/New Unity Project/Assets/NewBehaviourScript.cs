using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class NewBehaviourScript : MonoBehaviour {

    private Animator _SapphiArtChanAnimator;                //Character Animation
    private string _FireBaseData = "running";

    // Use this for initialization
    void Start () {
        Debug.Log("HelloWorld");

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://azesttest1.firebaseio.com");
        FirebaseDatabase.DefaultInstance
        .GetReference("Leaders")
        .ValueChanged += HandleValueChanged;

        _SapphiArtChanAnimator = this.gameObject.GetComponent<Animator>();

        SetAllAnimationFlagsToFalse();


    }
	
	// Update is called once per frame
	void Update () {

        GetAnimation();

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot

        Debug.Log(args.Snapshot.Value);

        _FireBaseData = args.Snapshot.Value.ToString();

        SetAllAnimationFlagsToFalse();

       
    }

    void SetAllAnimationFlagsToFalse()
    {
        _SapphiArtChanAnimator.SetBool("param_idletowalk", false);
        _SapphiArtChanAnimator.SetBool("param_idletorunning", false);
        _SapphiArtChanAnimator.SetBool("param_idletojump", false);
        _SapphiArtChanAnimator.SetBool("param_idletowinpose", false);
        _SapphiArtChanAnimator.SetBool("param_idletoko_big", false);
        _SapphiArtChanAnimator.SetBool("param_idletodamage", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit01", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit02", false);
        _SapphiArtChanAnimator.SetBool("param_idletohit03", false);
    }

    void GetAnimation()
    {
        //IDLE
        if (_FireBaseData == "idle")
        {
            _SapphiArtChanAnimator.SetBool("param_toidle", true);
        }

        //WALK
        else if (_FireBaseData == "walk")
        {
            _SapphiArtChanAnimator.SetBool("param_idletowalk", true);
        }

        //RUN
        else if (_FireBaseData == "running")
        {
            _SapphiArtChanAnimator.SetBool("param_idletorunning", true);
        }

        //JUMP
        else if (_FireBaseData == "jump")
        {
            _SapphiArtChanAnimator.SetBool("param_idletojump", true);
        }

        //WIN POSE
        else if (_FireBaseData == "winpose")
        {
            _SapphiArtChanAnimator.SetBool("param_idletowinpose", true);
        }

        //KO
        else if (_FireBaseData == "ko_big")
        {
            _SapphiArtChanAnimator.SetBool("param_idletoko_big", true);
        }

        //DAMAGE
        else if (_FireBaseData == "damage")
        {
            _SapphiArtChanAnimator.SetBool("param_idletodamage", true);
        }

        //HIT 1
        else if (_FireBaseData == "hit01")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit01", true);
        }

        //HIT 2
        else if (_FireBaseData == "hit02")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit02", true);
        }

        //HIT 3
        else if (_FireBaseData == "hit03")
        {
            _SapphiArtChanAnimator.SetBool("param_idletohit03", true);
        }
        else
        {
            _SapphiArtChanAnimator.SetBool("param_toidle", true);
        }
    }
}

