using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VivantioApi.Data;
using VivantioApi.Model;
using static VivantioApi.Data.CustomForms;
using static VivantioApi.Data.Tickets;

namespace Tickets.Con
{
    internal static class Program
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string valueSeparator = "  |  ";
        private const string sectionSeparator = "--------------------------------------------------";
        private static void Main()
        {
            // Not secure, for demo purposes only!!
            // These are the detais from Admin > Integrations & API > Downloads
            const string baseUrl = "url_here";
            const string username = "username_here";
            const string password = "password_here";
            Helper.ConfigureHttpClient(_client, baseUrl, username, password);
            Console.WriteLine(sectionSeparator);
            PrintAllUsers().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);
            PrintSingleTicketDetails().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);
            PrintAllCustomActionsByTicket().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);
            PrintAllChildTicketsById().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);
            PrintMultipleTickets().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);
            Console.ReadLine();
        }

        private static async Task PrintSingleTicketDetails()
        {
            const int ticketId = 10225;
            var std = await GetSingleTicketByIdAsync(_client, ticketId).ConfigureAwait(false);
            if (std != null)
            {
                Console.WriteLine($"ID: {std.Id}{valueSeparator}Title: { std.Title}{valueSeparator} " +
                    $"Open Date: { std.OpenDate}{valueSeparator} Caller Name: { std.CallerName}{valueSeparator} Description: { std.Description}{valueSeparator} Owner Name: { std.CallerName} ");
            }
        }
        private static async Task PrintAllUsers()
        {
            var usersList = await GetAllUsers(_client).ConfigureAwait(false);
            foreach (UserInfo user in usersList)
            {
                Console.WriteLine($"ID: {user.Id}{valueSeparator}Full Name: {user.FirstName +" "+ user.LastName}{valueSeparator} Email: {user.EmailAddress}");
            }
        }
        private static async Task PrintAllCustomActionsByTicket()
        {
            const int ticketTypeId = 10370;
            const bool includePrivate = false;
            const bool includeAttachements = false;
            var ticketActions = await GetAllActionsByTicketId(_client, ticketTypeId,includePrivate, includeAttachements).ConfigureAwait(false);
            foreach (TicketAction ta in ticketActions)
            {
                Console.WriteLine($"ID: {ta.Id}{valueSeparator}Description: {ta.Description}{valueSeparator} Action Date: {ta.ActionDate}{valueSeparator} Action UserName: {ta.ActionUserName}{valueSeparator} Action User Email :{ta.ActionUserEmail}");
            }
        }

        private static async Task PrintAllChildTicketsById()
        {
            const int ticketId = 10225;
            var childTickets = await GetChildTicketById(_client, ticketId).ConfigureAwait(false);
            foreach (TicketType ct in childTickets)
            {
                Console.WriteLine($"ID: {ct.Id}{valueSeparator}Title: { ct.Title}{valueSeparator} " +
                $"Open Date: { ct.OpenDate}{valueSeparator} Caller Name: { ct.CallerName}{valueSeparator} Description: { ct.Description}{valueSeparator} Owner Name: { ct.CallerName} ");
            }
        }

        private static async Task PrintMultipleTickets()
        {
            var tickets = new[]{ 10404, 10402, 10225 };
            var multipleTickets = await GetListofTickets(_client, tickets).ConfigureAwait(false);
            foreach (TicketType mt in multipleTickets)
            {
                Console.WriteLine($"ID: {mt.Id}{valueSeparator}Title: { mt.Title}{valueSeparator}Open Date: { mt.OpenDate}{valueSeparator} Caller Name: { mt.CallerName}{valueSeparator}Description: { mt.Description}{valueSeparator} Owner Name: { mt.CallerName} ");
            }
        }


    }
}
