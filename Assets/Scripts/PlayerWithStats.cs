using System.Collections;
using System.Collections.Generic;

public class PlayerWithStats {

    private Player player;
    private Tournament tournament;
    private List<Match> playedMatches = new List<Match>();
    private bool active;

    public PlayerWithStats(Player player, Tournament tournament)
    {
        this.player = player;
        this.tournament = tournament;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public Tournament GetTournament()
    {
        return tournament;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

    public bool GetActive()
    {
        return active;
    }

    public void AddPlayedMatches(Match match)
    {
        playedMatches.Add(match);
    }

    public int GetPoints()
    {
        int points = 0;
        for(int i = 0; i < playedMatches.Count; i++)
        {
            points += playedMatches[i].GetPlayerPoints(this);
        }
        return points;
    }
}