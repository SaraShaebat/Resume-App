﻿namespace BackendPart.Core.Dtos.Candidate
{
    public class CandidateGetDto
    {
        public long id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobId { get; set; }
        public string JobTitel { get; set; }

    }
}
