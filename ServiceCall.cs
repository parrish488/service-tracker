using System;

namespace ServiceTracker
{
    //Fix getters/setters and set up a constructor
    class ServiceCall
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Comments { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string CallTaker { get; set; }

        public string JobStatus { get; set; }

        public string Tech { get; set; }
    }
}
