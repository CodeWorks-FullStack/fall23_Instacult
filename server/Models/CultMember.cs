namespace Instacult.Models
{
    public class CultMember : RepoItem<int>
    {
        public string AccountId { get; set; }
        public int CultId { get; set; }
    }
}