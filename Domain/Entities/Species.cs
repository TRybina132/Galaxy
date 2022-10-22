using Azure;
using Azure.Data.Tables;
using ManagedCode.Repository.AzureTable;

namespace Domain.Entities
{
    public class Species : AzureTableItem
    {
        public string Name { get; set; }
    }
}
