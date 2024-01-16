using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/site")]
    public partial class site
    {
        public int id { get; set; }
        public Guid row_id { get; set; }
        public string name { get; set; } = null!;
        public string? prefix { get; set; }
        public string code { get; set; } = null!;
        public string? description { get; set; }
        public string? comments { get; set; }
        public bool? status { get; set; }
        public bool? deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
