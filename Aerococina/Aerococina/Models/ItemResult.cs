using System;
using System.Collections.Generic;

namespace Aerococina.Models
{
    public class ItemResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }

        public Dictionary<String, Object> Data { get; set; }

        public ItemResult()
        {
            Result = false;
            Message = String.Empty;
            Id = 0;
            Data = new Dictionary<string, object>();
        }
    }
}
