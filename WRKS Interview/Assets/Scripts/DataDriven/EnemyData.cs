[System.Serializable]
public class EnemyData
{
    public string name;
    public int health;
    public float speed;
    public int damage;
}

[System.Serializable]
public class EnemyDatabase
{
    public EnemyData[] enemies;
}