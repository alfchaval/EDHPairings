using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentsData : MonoBehaviour
{
	private List<Tournament> tournaments = new List<Tournament>();
	
	public List<Tournament> GetTournaments()
	{
		return tournaments;
	}
	
	public void AddTournament(Tournament tournament)
	{
		if(tournament.GetTournamentsData() == this && tournament.GetId() == tournaments[tournaments.Count - 1].GetId() + 1)
		{
			tournaments.Add(tournament);
		}
	}
	
	public Tournament GetTournament(int tournamentId)
	{
		if(tournamentId >= 0)
		{
			for(int i = 0; i < tournaments.Count; i++)
			{
				if(tournaments[i].GetId() == tournamentId)
				{
					return tournaments[i];
				}
			}
		}
		return null;
	}
	
	public void UpdateData(Tournament tournament)
	{
		
	}
}
