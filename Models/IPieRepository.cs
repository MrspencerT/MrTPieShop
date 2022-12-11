namespace BethanyPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> All { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById(int pieId);
    }
}
