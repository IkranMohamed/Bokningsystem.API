namespace Bokningsystem.API.DTOs
{
    public class CreateBokningDto
    {
        public int AnvandareId { get; set; }
        public int TjanstId { get; set; }
        public DateTime DatumTid { get; set; }
    }
}
