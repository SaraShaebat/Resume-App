using BackendPart.Core.Enums;

namespace BackendPart.Core.Dtos.Company
{
    public class CompanyGetDto
    {
        public long id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public CompanySize Size { get; set; }

    }
}
