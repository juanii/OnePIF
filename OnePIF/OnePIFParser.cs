using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OnePIF
{
    public class OnePIFParser
    {
        private static readonly string recordSeparator = "***5642bee8-a5ff-11dc-8314-0800200c9a66***";

        public List<Records.BaseRecord> Parse(Stream input)
        {
            List<Records.BaseRecord> records = new List<Records.BaseRecord>();

            using (TextReader textReader = new StreamReader(input))
            {
                StringBuilder stringBuilder = null;
                string line = textReader.ReadLine();

                while (line != null)
                {
                    stringBuilder = new StringBuilder();

                    while (line != null && !line.Equals(recordSeparator))
                    {
                        stringBuilder.AppendLine(line);
                        line = textReader.ReadLine();
                    }

                    string stringRecord = stringBuilder.ToString();

                    if (!string.IsNullOrEmpty(stringRecord))
                    {
                        Records.BaseRecord record = JsonConvert.DeserializeObject<Records.BaseRecord>(stringRecord);

                        // Unknown records are currently not imported
                        if (record != null && !(record is Records.UnknownRecord))
                            records.Add(record as Records.BaseRecord);
                    }

                    line = textReader.ReadLine();
                }
            }

            return records;
        }
    }
}
