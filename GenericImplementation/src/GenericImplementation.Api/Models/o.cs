using System;
using System.Collections.Generic;

namespace GenericImplementation.Api.Models
{
    [GeneratedController("api/os")]
    public partial class o
    {
        public o()
        {
            edges = new HashSet<edge>();
        }

        public int id { get; set; }
        public Guid row_id { get; set; }
        public string name { get; set; } = null!;
        public string code { get; set; } = null!;
        public bool? status { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public bool deleted { get; set; }

        public virtual ICollection<edge> edges { get; set; }
    }
}
