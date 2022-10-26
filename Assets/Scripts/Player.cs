public class Player {
	private int id;
    private string name;

    public Player(string name)
    {
		this.id = PlayersData.instance.GetPlayers()[PlayersData.instance.GetPlayers().Count - 1].GetId() + 1;
        PlayersData.instance.AddPlayer(this);
        this.name = name;
    }

    public int GetId()
    {
        return id;
    }

    public void SetName(string name)
    {
        this.name = name;
        PlayersData.instance.UpdateData(this);
    }

    public string GetName()
    {
        return name;
    }
	
    public override bool Equals(System.Object other)
	{
        return (other != null && other is Player && this.id == ((Player)other).id);
    }
	
	public override int GetHashCode()
	{
		return id;
	}
}