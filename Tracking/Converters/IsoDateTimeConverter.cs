using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Converters
{
    public class IsoDateTimeConverter : DateTimeConverterBase
    {
        public IsoDateTimeConverter();

        public CultureInfo Culture { get; set; }
        public string DateTimeFormat { get; set; }
        public DateTimeStyles DateTimeStyles { get; set; }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer);
    }
}
