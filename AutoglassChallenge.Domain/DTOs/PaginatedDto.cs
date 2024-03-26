namespace AutoglassChallenge.Domain.DTOs
{
    public class PaginatedDto<t>
    {
        public int TotalItems { get; set; }
        public int ItemsByPage { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<t> Items { get; set; }
    }
}
