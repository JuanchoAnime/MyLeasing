﻿namespace MyLeasing.Common.Response
{
    public class LesseeResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
