using System;

namespace VivantioApi.Model
{
    public class TicketType
    {
        public int Id { get; set; }
        public string NameSingular { get; set; }
        public string Title { get; set; }
        public string CallerName { get; set; }
        public DateTime OpenDate { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }       

    }
}