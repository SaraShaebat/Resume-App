using BackendPart.Core.Entities;
using BackendPart.Core.Enums;

namespace BackendPart.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
    }
}
