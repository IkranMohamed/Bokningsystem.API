namespace Bokningsystem.API.Models
{
    public class Bokning
    {
        public int Id { get; set; }

        public int AnvandareId { get; set; }
        public Anvandare Anvandare { get; set; }

        public int TjanstId { get; set; }
        public Tjanst Tjanst { get; set; }

        public DateTime DatumTid { get; set; }
    }
}
