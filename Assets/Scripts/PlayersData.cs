using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersData : MonoBehaviour
{
    private List<Player> players = new List<Player>();

	public static PlayersData instance;

    private void Start()
    {
		//LoadData();
		instance = this;
    }

    public List<Player> GetPlayers()
	{
		return players;
	}
	
	public void AddPlayer(Player player)
	{
		if(player.GetId() == players[players.Count - 1].GetId() + 1)
		{
			players.Add(player);
		}
	}
	
	public Player GetPlayer(int playerId)
	{
		if(playerId >= 0)
		{
			for(int i = 0; i < players.Count; i++)
			{
				if(players[i].GetId() == playerId)
				{
					return players[i];
				}
			}
		}
		return null;
	}
	
	public void UpdateData(Player player)
	{

	}
}
