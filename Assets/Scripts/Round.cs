using System.Collections;
using System.Collections.Generic;

public class Round {

    private Tournament tournament;
    private int roundNumber;
    private List<Match> matches = new List<Match>();
    private bool finished;

    public Round(Tournament tournament, int roundNumber)
    {
        this.tournament = tournament;
        this.roundNumber = roundNumber;
    }

    public void SetMatches(List<Match> matches)
    {
        this.matches = matches;
    }

    public List<Match> GetMatches()
    {
        return matches;
    }

    public void MatchFinished(Match match)
    {
        for(int i = 0; i < matches.Count; i++)
        {
            if(!matches[i].IsFinished())
            {
                return;
            }
        }
        finished = true;
        tournament.MatchFinished(roundNumber);
    }

    public bool GetFinished()
    {
        return finished;
    }

    public bool IsActive(PlayerWithStats player)
    {
        return GetPlayerMatch(player) != null;
    }

    public Match GetPlayerMatch(PlayerWithStats player)
    {
        for(int i = 0; i < matches.Count; i++)
        {
            if(matches[i].IsPlayerInMatch(player))
            {
                return matches[i];
            }
        }
        return null;
    }
}