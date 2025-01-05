using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;
using System.Data;

namespace ETicaretAPI.API.Configurations.ColumnWriters
{
    public class UsernameColumnWriter : ColumnWriterBase
    {
        public UsernameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
          var (username,value)  =  logEvent.Properties.FirstOrDefault(p => p.Key == "user_sname");

            return value?.ToString() ?? null;
        }
    }
}
