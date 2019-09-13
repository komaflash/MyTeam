

using System;
using System.ComponentModel.DataAnnotations;

namespace MyTeam.Entities
{
    public interface ITimestampedEntity
    {
        [DataType(DataType.DateTime)]
        DateTime CreatedAt {get; set;}
        [DataType(DataType.DateTime)]
        DateTime LastModified {get; set;}
    }
}