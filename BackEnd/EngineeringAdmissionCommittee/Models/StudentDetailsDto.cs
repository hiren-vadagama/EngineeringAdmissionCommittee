﻿namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class StudentDetailsDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
    }
}
