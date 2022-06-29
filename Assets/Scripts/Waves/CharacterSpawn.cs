
public class CharacterSpawn
{
    private Character _template;
    private int _amount;

    public Character Template { get => _template; }
    public int Amount { get => _amount; }

    public CharacterSpawn(Character template, int amount)
    {
        _template = template;
        _amount = amount;
    }


}

