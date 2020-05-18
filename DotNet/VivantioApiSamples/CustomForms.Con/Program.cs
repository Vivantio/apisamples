using System;
using System.Net.Http;
using System.Threading.Tasks;
using VivantioApi.Data;
using VivantioApi.Model;
using static VivantioApi.Data.CustomForms;

namespace CustomForms.Con
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
            PrintTicketTypes().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            PrintCustomFormDefinitionsForTicketType().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            PrintCustomFormDefinitionDetailForTicketType().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            PrintCustomFormDefinitionsForTicketInstance().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            PrintCustomFieldDefinition().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            PrintCustomFormInstanceForTicketInstance().GetAwaiter().GetResult();
            Console.WriteLine(sectionSeparator);

            Console.ReadLine();
        }

        private static async Task PrintTicketTypes()
        {
            var ticketTypes = await GetTicketTypeAsync(_client).ConfigureAwait(false);

            foreach (TicketType tt in ticketTypes)
            {
                Console.WriteLine($"ID: {tt.Id}{valueSeparator}Name: {tt.NameSingular}");
            }
        }

        private static async Task PrintCustomFormDefinitionsForTicketType()
        {
            // supply a value returned from PrintTicketTypes()
            const int ticketTypeId = 54;

            var cfds = await GetCustomFormDefinitionForTicketTypeAsync(_client, ticketTypeId).ConfigureAwait(false);

            foreach (FormDefinition cfd in cfds)
            {
                Console.WriteLine($"ID: {cfd.Id}{valueSeparator}Name: {cfd.Name}");
            }
        }

        private static async Task PrintCustomFormDefinitionDetailForTicketType()
        {
            // supply a value returned from PrintTicketTypes()
            const int formDefinitionId = 9799;

            var fds = await GetCustomFormDefinitionDetailForFormDefinitionIdAsync(_client, formDefinitionId).ConfigureAwait(false);

            Console.WriteLine($"ID: {fds.Id}{valueSeparator}Name: { fds.Name}");
        }

        private static async Task PrintCustomFormDefinitionsForTicketInstance()
        {
            const int ticketInstanceId = 655984;
            const string systemArea = "Ticket";

            var cfds = await GetCustomFormDefinitionForTicketInstanceAsync(_client, ticketInstanceId, systemArea).ConfigureAwait(false);

            foreach (string cfd in cfds)
            {
                Console.WriteLine($"ID: {cfd}");
            }
        }

        private static async Task PrintCustomFieldDefinition()
        {
            const int fieldDefinitionId = 13289;

            var fd = await GetCustomFieldDefinitionAsync(_client, fieldDefinitionId).ConfigureAwait(false);

            Console.WriteLine($"ID: {fd.Id}{valueSeparator}Name: { fd.Name}{valueSeparator}Label: {fd.Label}");
        }

        private static async Task PrintCustomFormInstanceForTicketInstance()
        {
            const int typeId = 0;
            const int ticketTypeId = 655984;
            const string systemArea = "Ticket";

            var fis = await GetCustomFormInstanceForTicketInstanceAsync(_client, typeId, ticketTypeId, systemArea).ConfigureAwait(false);

            foreach (FormInstance fi in fis)
            {
                Console.WriteLine($"ID: {fi.Id}{valueSeparator}Definition ID: { fi.CustomEntityDefinitionId}{valueSeparator}Parent ID: {fi.ParentId}");
            }
        }
    }
}
