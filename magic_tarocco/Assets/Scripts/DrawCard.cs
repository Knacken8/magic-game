using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCard : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    public void Start()
    {

    }

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager> ();
        PlayerManager.CmdDealCards();
    }
}
