using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeterCharge
{
    public interface IDataSaver
    {
        void Save(Meter meter, List<Tuple<int, int>> ReadingCharges);
    }
    public class FilePersistance : IDataSaver
    {
        private FilePersistance()
        {
            if (!Directory.Exists(@"C:\MeterDb\"))
            {
                Directory.CreateDirectory(@"C:\MeterDb\");
            }
        }
        private static Lazy<FilePersistance> instance =
            new Lazy<FilePersistance>(() => new FilePersistance());
        public static FilePersistance Instance => instance.Value;
        public void Save(Meter meter, List<Tuple<int, int>> readingCharges)
        {
            var filename = "Meter" + meter.Id + ".log";
            StreamWriter writer = File.AppendText(@"C:\MeterDb\" + filename);
            writer.Write("Timestamp".PadRight(20, ' ') + "\t" +
                "Meter Type".PadRight(15, ' ') + "\t" +
                "Consumption".PadRight(15, ' ') + "\t" +
                "Cost".PadRight(15, ' ') + "\t" +
                "Charge".PadRight(15, ' ') + "\t" + Environment.NewLine);
            writer.AutoFlush = true;
            StringBuilder sb = new StringBuilder();
            foreach (var readingcharge in readingCharges)
            {
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                sb.Append("\t");
                sb.Append(meter.MeterType.ToString().PadRight(15, ' '));
                sb.Append("\t");
                sb.Append(readingcharge.Item1.ToString().PadRight(15, ' '));
                sb.Append("\t");
                sb.Append(meter.Cost.ToString().PadRight(15, ' '));
                sb.Append("\t");
                sb.Append(readingcharge.Item2.ToString().PadRight(15, ' '));
                sb.Append("\t");
                sb.Append(Environment.NewLine);
            }


            writer.Write(sb.ToString());
        }
    }
}

