﻿using System.Text.Json.Serialization;
using System.Text.Json;

namespace StudyCenter.Shared.Infraestrutura.Backend.Configurations
{
    public static class JsonHelper
    {
        public static string SerializeToJson(object obj)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return JsonSerializer.Serialize(obj, options);
        }
    }
}
