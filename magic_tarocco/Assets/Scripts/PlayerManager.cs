using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject HandArea;
    public GameObject CreatureArea;
    public GameObject EnemyArea;

    List<GameObject> cards = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();
        HandArea = GameObject.Find("HandArea");
        CreatureArea = GameObject.Find("CreatureArea");
        EnemyArea = GameObject.Find("EnemyArea");
    }

    [Server]
    public override void OnStartServer() 
    {
        base.OnStartServer();

        cards.Add(Card1);

    }

    [Command]
    public void CmdDealCards()
    {
        GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(card, connectionToClient);
        RpcShowCard(card, "Dealt");

    }
    [ClientRpc]
    void RpcShowCard(GameObject card, string type) 
    {
        if (type == "Dealt") 
        {
            if (hasAuthority)
            {
                card.transform.SetParent(HandArea.transform, false);
            }
            else 
            {
                card.transform.SetParent(EnemyArea.transform, false);
            }
        }
        else if (type == "Played") 
        {

        }
    }
}
