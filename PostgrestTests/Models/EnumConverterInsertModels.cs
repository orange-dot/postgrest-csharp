using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace PostgrestTests.Models
{
    public enum DoorStatus
    {
        Open,
        Closed
    }

    [Table("doors")]
    public class DoorWithPropertyConverter : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DoorStatus Status { get; set; }
    }

    [Table("doors")]
    public class NullableDoorWithPropertyConverter : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DoorStatus? Status { get; set; }
    }

    [Table("doors")]
    public class DoorWithIgnoredFields : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DoorStatus Status { get; set; }

        [Column("ignore_on_insert", ignoreOnInsert: true)]
        public string? IgnoreOnInsert { get; set; }

        [Column("ignore_on_update", ignoreOnUpdate: true)]
        public string? IgnoreOnUpdate { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
