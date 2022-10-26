using System.Collections;
using System.Collections.Generic;

public class Tournament {

	private TournamentsData tournamentsData;
	private int id;
	
	private List<PlayerWithStats> players = new List<PlayerWithStats>();
    private List<Round> rounds = new List<Round>();
    private int currentRound = 0;
	
	public Tournament(TournamentsData tournamentsData)
	{
		this.tournamentsData = tournamentsData;
		this.id = tournamentsData.GetTournaments()[tournamentsData.GetTournaments().Count - 1].GetId() + 1;
		tournamentsData.AddTournament(this);
	}
	
	public TournamentsData GetTournamentsData()
	{
		return tournamentsData;
	}
	
	public int GetId()
    {
        return id;
    }

    public void AddPlayer(Player player)
    {
        players.Add(new PlayerWithStats(player, this));
    }

    public void AddRound()
    {

    }

    public void MatchFinished(int roundNumber)
    {

    }
}