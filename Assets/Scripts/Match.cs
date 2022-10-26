using System.Collections;
using System.Collections.Generic;

public class Match {

    private Round round;
    private int matchId;
    private List<PlayerWithStats> players = new List<PlayerWithStats>();
    private int[] positions;
    private int[] points;
    private bool finished;

    public Match(Round round, int matchId)
    {
        this.round = round;
        this.matchId = matchId;
    }

    public void SetPlayers(List<PlayerWithStats> players)
    {
        this.players = players;
        this.positions = new int[players.Count];
        this.points = new int[players.Count];
        for(int i = 0; i < players.Count; i++)
        {
            players[i].AddPlayedMatches(this);
        }
    }

    public Round GetRound()
    {
        return round;
    }

    public int getMatchId()
    {
        return matchId;
    }

    public List<PlayerWithStats> GetPlayers()
    {
        return players;
    }

    public bool SetPositions(int[] positions)
    {
        if(CheckValidPositions(positions))
        {
            this.positions = positions;
            NormalizePositions();
            SetPoints();
            finished = true;
            round.MatchFinished(this);
            return true;
        }
        return false;
    }

    public int[] GetPositions()
    {
        return positions;
    }

    public int GetPlayerPosition(PlayerWithStats player)
    {
        int index = players.IndexOf(player);
        return index >= 0 ? positions[index] : -1;
    }

    public void DeletePositions()
    {
        this.positions = new int[players.Count];
        finished = false;
    }

    public int[] GetPoints()
    {
        return points;
    }

    public int GetPlayerPoints(PlayerWithStats player)
    {
        int index = players.IndexOf(player);
        return index >= 0 ? points[index] : -1;
    }

    public bool IsFinished()
    {
        return finished;
    }

    public bool CheckValidPositions(int[] positions)
    {
        int numberOfPlayers = players.Count;
        if(numberOfPlayers != positions.Length)
        {
            return false;
        }
        for(int i = 0; i < positions.Length; i++)
        {
            if(positions[i] < 1 || positions[i] > numberOfPlayers )
            {
                return false;
            }
        }
        return true;
    }

    public bool IsPlayerInMatch(PlayerWithStats player)
    {
        return players.IndexOf(player) >= 0;
    }

    public void NormalizePositions()
    {
        int lowerPosition;
        for(int i = 1; i < positions.Length; i++)
        {
            lowerPosition = 0;
            for(int j = 0; j < positions.Length; j++)
            {
                if(positions[j] >= i && (lowerPosition == 0 || positions[j] < lowerPosition))
                {
                    lowerPosition = positions[j];
                }
            }
            if(lowerPosition > i)
            {
                for(int k = 0; k < positions.Length; k++)
                {
                    if(positions[k] > i)
                    {
                        positions[k] -= lowerPosition - i;
                    }
                }
            }
        }
    }

    private ResultType CheckResultType()
    {
        int n1 = 0;
        int n2 = 0;
        int n3 = 0;
        for(int i = 0; i < positions.Length; i++)
        {
            switch (positions[i])
            {
                case 1:
                    n1++;
                    break;
                case 2:
                    n2++;
                    break;
                case 3:
                    n3++;
                    break;
            }
        }
        switch (positions.Length)
        {
            case 3:
                switch (n1)
                {
                    case 1:
                        switch (n2)
                        {
                            case 1:
                                return ResultType.R123;
                            case 2:
                                return ResultType.R122;
                        }
                        break;
                    case 2:
                        return ResultType.R112;
                    case 3:
                        return ResultType.R111;
                }
                break;
            case 4:
                switch (n1)
                {
                    case 1:
                        switch (n2)
                        {
                            case 1:
                                switch (n3)
                                {
                                    case 1:
                                        return ResultType.R1234;
                                    case 2:
                                        return ResultType.R1233;
                                }
                                break;
                            case 2:
                                return ResultType.R1223;
                            case 3:
                                return ResultType.R1222;
                        }
                        break;
                    case 2:
                        switch (n2)
                        {
                            case 1:
                                return ResultType.R1123;
                            case 2:
                                return ResultType.R1122;
                        }
                        break;
                    case 3:
                        return ResultType.R1112;
                    case 4:
                        return ResultType.R1111;
                }
                break;
        }
        return  ResultType.ERROR;
    }

    private void SetPoints()
    {
        switch (CheckResultType())
        {
            case ResultType.R1111:
                LinkPoints(new int[]{8});
                break;
            case ResultType.R1222:
                LinkPoints(new int[]{14,6});
                break;
            case ResultType.R1122:
                LinkPoints(new int[]{12,4});
                break;
            case ResultType.R1233:
                LinkPoints(new int[]{14,10,4});
                break;
            case ResultType.R1112:
                LinkPoints(new int[]{10,2});
                break;
            case ResultType.R1223:
                LinkPoints(new int[]{14,8,2});
                break;
            case ResultType.R1123:
                LinkPoints(new int[]{12,6,2});
                break;
            case ResultType.R1234:
                LinkPoints(new int[]{14,10,6,2});
                break;
            case ResultType.R111:
                LinkPoints(new int[]{8});
                break;
            case ResultType.R122:
                LinkPoints(new int[]{14,5});
                break;
            case ResultType.R112:
                LinkPoints(new int[]{11,2});
                break;
            case ResultType.R123:
                LinkPoints(new int[]{14,8,2});
                break;
        }
    }

    private void LinkPoints(int[] values)
    {
        for(int i = 0; i < positions.Length; i++)
        {
            points[i] = values[positions[i]];
        }
    }

    private enum ResultType
    {
        R1111,
        R1222,
        R1122,
        R1233,
        R1112,
        R1223,
        R1123,
        R1234,
        R111,
        R122,
        R112,
        R123,
        ERROR
    }
}