using BackendPart.Core.Enums;

namespace BackendPart.Core.Dtos.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
